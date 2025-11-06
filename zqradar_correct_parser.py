#!/usr/bin/env python3
"""
DOĞRU ZQRadar Parser - Request/Response ile Local Player Pozisyonu
"""

import struct
from typing import Dict, List, Any, Optional
from zqradar_real_parser import Protocol16Deserializer, Protocol16Type

# ============================================================================
# OPERATION CODES (Request/Response)
# ============================================================================

class OperationCodes:
    """Photon Operation Codes"""
    JOIN = 2            # Join map (response)
    MOVE = 21           # Player move (request)
    CHANGE_CLUSTER = 35 # Change cluster (response)


# ============================================================================
# EXTENDED DESERIALIZER (Request/Response desteği)
# ============================================================================

class Protocol16DeserializerExtended(Protocol16Deserializer):
    """Extended deserializer with Operation support"""

    def deserialize_operation_request(self) -> Dict:
        """
        OperationRequest parse
        ZQRadar: {operationCode, parameters}
        """
        operation_code = self.read_uint8()
        parameters = self.deserialize_parameter_table()

        # Operation code'u parameters[253]'e ekle (ZQRadar compat)
        parameters[253] = operation_code

        return {'operationCode': operation_code, 'parameters': parameters}

    def deserialize_operation_response(self) -> Dict:
        """
        OperationResponse parse
        ZQRadar: {operationCode, returnCode, debugMessage, parameters}
        """
        operation_code = self.read_uint8()
        return_code = self.read_uint16()

        # Debug message (optional)
        debug_type = self.read_uint8()
        debug_message = self.deserialize(debug_type) if debug_type else None

        parameters = self.deserialize_parameter_table()

        # Operation code'u parameters[253]'e ekle
        parameters[253] = operation_code

        return {
            'operationCode': operation_code,
            'returnCode': return_code,
            'debugMessage': debug_message,
            'parameters': parameters
        }


# ============================================================================
# PHOTON COMMAND PARSER (REQUEST/RESPONSE desteği ile)
# ============================================================================

class PhotonCommand:
    """
    Photon command parser
    REQUEST ve RESPONSE mesajlarını da parse eder
    """

    def __init__(self, data: bytes):
        self.data = data
        self.pos = 0

        self.command_type = 0
        self.channel_id = 0
        self.command_flags = 0
        self.command_length = 0
        self.sequence_number = 0
        self.message_type = 0
        self.result = None

        self.parse_command()

    def parse_command_header(self):
        """Command header parse (12 byte)"""
        if len(self.data) < 12:
            return False

        self.command_type = self.data[0]
        self.channel_id = self.data[1]
        self.command_flags = self.data[2]
        # Skip 1 byte
        self.command_length = struct.unpack('>I', self.data[4:8])[0]
        self.sequence_number = struct.unpack('>I', self.data[8:12])[0]

        self.pos = 12
        return True

    def parse_command(self):
        """Command parse et"""
        if not self.parse_command_header():
            return

        # Command data
        if self.command_length < 12:
            return

        command_data = self.data[self.pos:self.pos + self.command_length - 12]

        # Command type
        if self.command_type == 6:  # Reliable
            self.parse_reliable_command(command_data)
        elif self.command_type == 7:  # Unreliable
            # Skip 4 bytes
            self.parse_reliable_command(command_data[4:])

    def parse_reliable_command(self, data: bytes):
        """Reliable command parse"""
        if len(data) < 2:
            return

        # Skip 1 byte, read message type
        self.message_type = data[1]
        payload = data[2:]

        # DOĞRU: Extended deserializer kullan (Request/Response desteği için)
        deserializer = Protocol16DeserializerExtended(payload)

        try:
            if self.message_type == 2:  # OperationRequest
                self.result = deserializer.deserialize_operation_request()
                self.result['message_type'] = 'request'

            elif self.message_type == 3:  # OperationResponse
                self.result = deserializer.deserialize_operation_response()
                self.result['message_type'] = 'response'

            elif self.message_type == 4:  # EventData
                self.result = deserializer.deserialize_event_data()
                self.result['message_type'] = 'event'

        except Exception as e:
            print(f"Parse error: {e}")


# ============================================================================
# PHOTON PACKET PARSER (Düzeltilmiş)
# ============================================================================

class PhotonPacketCorrect:
    """
    Düzeltilmiş Photon packet parser
    Request/Response mesajlarını da parse eder
    """

    def __init__(self, data: bytes):
        self.data = data
        self.pos = 0

        # Header
        self.peer_id = 0
        self.flags = 0
        self.command_count = 0
        self.timestamp = 0
        self.challenge = 0

        # Commands
        self.commands = []

        self.parse_packet()

    def parse_photon_header(self):
        """Photon header parse (12 byte)"""
        if len(self.data) < 12:
            return False

        self.peer_id = struct.unpack('>H', self.data[0:2])[0]
        self.flags = self.data[2]
        self.command_count = self.data[3]
        self.timestamp = struct.unpack('>I', self.data[4:8])[0]
        self.challenge = struct.unpack('>I', self.data[8:12])[0]
        self.pos = 12
        return True

    def parse_packet(self):
        """Paketi parse et"""
        if not self.parse_photon_header():
            return

        for _ in range(self.command_count):
            if self.pos >= len(self.data):
                break

            command = PhotonCommand(self.data[self.pos:])
            if command.result:
                self.commands.append(command.result)

            # Sonraki command'e atla
            if command.command_length > 0:
                self.pos += command.command_length
            else:
                break


# ============================================================================
# KULLANIM - DOĞRU VERSİYON
# ============================================================================

def parse_photon_packet_correct(raw_packet: bytes) -> Optional[Dict]:
    """
    DOĞRU parsing - Request/Response desteği ile

    Returns:
        {
            'local_player_pos': (x, y) or None,
            'events': [...],
            'requests': [...],
            'responses': [...]
        }
    """
    try:
        packet = PhotonPacketCorrect(raw_packet)

        result = {
            'local_player_pos': None,
            'events': [],
            'requests': [],
            'responses': []
        }

        for command in packet.commands:
            msg_type = command.get('message_type')

            if msg_type == 'request':
                result['requests'].append(command)

                # Player move request (Operation 21)
                params = command.get('parameters', {})
                if params.get(253) == OperationCodes.MOVE:
                    if 1 in params and isinstance(params[1], list) and len(params[1]) >= 2:
                        result['local_player_pos'] = (params[1][0], params[1][1])
                        print(f"🚶 Local Player MOVE: ({params[1][0]:.1f}, {params[1][1]:.1f})")

            elif msg_type == 'response':
                result['responses'].append(command)

                # Join map response (Operation 2)
                params = command.get('parameters', {})
                if params.get(253) == OperationCodes.JOIN:
                    if 9 in params and isinstance(params[9], list) and len(params[9]) >= 2:
                        result['local_player_pos'] = (params[9][0], params[9][1])
                        print(f"🎮 Local Player JOIN: ({params[9][0]:.1f}, {params[9][1]:.1f})")

            elif msg_type == 'event':
                result['events'].append(command)

        return result

    except Exception as e:
        print(f"Packet parse error: {e}")
        return None


# ============================================================================
# TEST
# ============================================================================

if __name__ == "__main__":
    print("╔══════════════════════════════════════════════════╗")
    print("║   DOĞRU ZQRadar Parser - Request/Response       ║")
    print("╚══════════════════════════════════════════════════╝\n")

    print("✅ Local player pozisyonu:")
    print("   - Request (Op 21): Player move")
    print("   - Response (Op 2): Join map")
    print()
    print("❌ Event 3 (Move): Sadece BAŞKA oyuncular/moblar için!")
    print()
    print("Kullanım:")
    print()
    print("  from zqradar_correct_parser import parse_photon_packet_correct")
    print()
    print("  result = parse_photon_packet_correct(packet_data)")
    print()
    print("  if result['local_player_pos']:")
    print("      x, y = result['local_player_pos']")
    print("      print(f'Sen: ({x}, {y})')")
