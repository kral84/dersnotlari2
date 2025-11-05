#!/usr/bin/env python3
"""
GERÇEK ZQRadar Photon Parser - Python Implementasyonu
ZQRadar'ın kaynak kodundan çevrildi
"""

import struct
from typing import Dict, List, Any, Optional
from enum import IntEnum

# ============================================================================
# PROTOCOL16 TYPE CODES
# ============================================================================

class Protocol16Type(IntEnum):
    """Photon Protocol 16 veri tipleri"""
    Unknown = 0
    Null = 1
    Dictionary = 2
    StringArray = 3
    Byte = 4
    Double = 5
    EventData = 6
    Float = 7
    Integer = 8
    Short = 9
    Long = 10
    IntegerArray = 11
    Boolean = 12
    OperationResponse = 13
    OperationRequest = 14
    String = 15
    ByteArray = 16
    Array = 17
    ObjectArray = 18
    Hashtable = 19


# ============================================================================
# EVENT CODES (ZQRadar'dan)
# ============================================================================

class EventCodes(IntEnum):
    """Albion Online event kodları"""
    Move = 3
    Teleport = 4
    NewSimpleHarvestableObject = 38
    NewHarvestableObject = 40
    HarvestStart = 59
    HarvestFinished = 61
    Mounted = 209
    InCombatStateUpdate = 273
    PlayerMovementRateUpdate = 320


# ============================================================================
# PROTOCOL16 DESERIALIZER
# ============================================================================

class Protocol16Deserializer:
    """
    ZQRadar'ın Protocol16Deserializer.js'inin Python çevirisi
    Binary Photon verilerini Python objelerine çevirir
    """

    def __init__(self, data: bytes):
        self.data = data
        self.pos = 0

    def read_bytes(self, n: int) -> bytes:
        """N byte oku"""
        result = self.data[self.pos:self.pos + n]
        self.pos += n
        return result

    def read_uint8(self) -> int:
        """uint8 oku (1 byte)"""
        return struct.unpack('>B', self.read_bytes(1))[0]

    def read_uint16(self) -> int:
        """uint16 Big Endian (2 byte)"""
        return struct.unpack('>H', self.read_bytes(2))[0]

    def read_uint32(self) -> int:
        """uint32 Big Endian (4 byte)"""
        return struct.unpack('>I', self.read_bytes(4))[0]

    def read_int64(self) -> int:
        """int64 Big Endian (8 byte)"""
        return struct.unpack('>q', self.read_bytes(8))[0]

    def read_float(self) -> float:
        """float Big Endian (4 byte)"""
        return struct.unpack('>f', self.read_bytes(4))[0]

    def read_double(self) -> float:
        """double Big Endian (8 byte)"""
        return struct.unpack('>d', self.read_bytes(8))[0]

    def read_string(self) -> str:
        """String oku (2 byte size + UTF-8 data)"""
        size = self.read_uint16()
        if size == 0:
            return ""
        return self.read_bytes(size).decode('utf-8')

    def deserialize(self, type_code: int) -> Any:
        """Type code'a göre deserialize et"""
        if type_code == Protocol16Type.Null or type_code == Protocol16Type.Unknown:
            return None
        elif type_code == Protocol16Type.Byte:
            return self.read_uint8()
        elif type_code == Protocol16Type.Boolean:
            return self.read_uint8() != 0
        elif type_code == Protocol16Type.Short:
            return self.read_uint16()
        elif type_code == Protocol16Type.Integer:
            return self.read_uint32()
        elif type_code == Protocol16Type.Long:
            return self.read_int64()
        elif type_code == Protocol16Type.Float:
            return self.read_float()
        elif type_code == Protocol16Type.Double:
            return self.read_double()
        elif type_code == Protocol16Type.String:
            return self.read_string()
        elif type_code == Protocol16Type.IntegerArray:
            return self.deserialize_integer_array()
        elif type_code == Protocol16Type.StringArray:
            return self.deserialize_string_array()
        elif type_code == Protocol16Type.ByteArray:
            return self.deserialize_byte_array()
        elif type_code == Protocol16Type.Array:
            return self.deserialize_array()
        elif type_code == Protocol16Type.Dictionary:
            return self.deserialize_dictionary()
        elif type_code == Protocol16Type.Hashtable:
            return self.deserialize_hashtable()
        else:
            raise ValueError(f"Unsupported type code: {type_code}")

    def deserialize_integer_array(self) -> List[int]:
        """Integer array oku"""
        size = self.read_uint32()
        return [self.read_uint32() for _ in range(size)]

    def deserialize_string_array(self) -> List[str]:
        """String array oku"""
        size = self.read_uint16()
        return [self.read_string() for _ in range(size)]

    def deserialize_byte_array(self) -> bytes:
        """Byte array oku"""
        size = self.read_uint32()
        return self.read_bytes(size)

    def deserialize_array(self) -> List[Any]:
        """Genel array oku"""
        size = self.read_uint16()
        type_code = self.read_uint8()
        return [self.deserialize(type_code) for _ in range(size)]

    def deserialize_dictionary(self) -> Dict:
        """Dictionary oku"""
        key_type = self.read_uint8()
        value_type = self.read_uint8()
        size = self.read_uint16()
        return self.deserialize_dictionary_elements(size, key_type, value_type)

    def deserialize_hashtable(self) -> Dict:
        """Hashtable oku"""
        size = self.read_uint16()
        return self.deserialize_dictionary_elements(size, 0, 0)

    def deserialize_dictionary_elements(self, size: int, key_type: int, value_type: int) -> Dict:
        """Dictionary elementlerini oku"""
        result = {}
        for _ in range(size):
            # Key
            if key_type == 0 or key_type == 42:
                k_type = self.read_uint8()
            else:
                k_type = key_type
            key = self.deserialize(k_type)

            # Value
            if value_type == 0 or value_type == 42:
                v_type = self.read_uint8()
            else:
                v_type = value_type
            value = self.deserialize(v_type)

            result[key] = value

        return result

    def deserialize_parameter_table(self) -> Dict:
        """Parameter table oku"""
        table_size = self.read_uint16()
        self.pos += 1  # Skip 1 byte

        table = {}
        for _ in range(table_size):
            key = self.read_uint8()
            value_type = self.read_uint8()
            value = self.deserialize(value_type)
            table[key] = value

        return table

    def deserialize_event_data(self) -> Dict:
        """
        Event data oku
        ZQRadar'ın deserializeEventData() fonksiyonu
        """
        code = self.read_uint8()
        parameters = self.deserialize_parameter_table()

        # Özel durum: Event 3 (Move)
        if code == 3:
            # ZQRadar'ın yaptığı gibi:
            # var bytes = new Uint8Array(parameters[1]);
            # var position0 = new DataView(bytes.buffer, 9, 4).getFloat32(0, true);
            # var position1 = new DataView(bytes.buffer, 13, 4).getFloat32(0, true);

            if 1 in parameters and isinstance(parameters[1], bytes):
                bytes_data = parameters[1]

                if len(bytes_data) >= 17:  # 9 + 4 + 4 = 17
                    # Little Endian float (true parametresi)
                    posX = struct.unpack('<f', bytes_data[9:13])[0]
                    posY = struct.unpack('<f', bytes_data[13:17])[0]

                    parameters[4] = posX
                    parameters[5] = posY
                    parameters[252] = 3

        return {'code': code, 'parameters': parameters}


# ============================================================================
# PHOTON PACKET PARSER
# ============================================================================

class PhotonPacket:
    """
    ZQRadar'ın PhotonPacket.js'inin Python çevirisi
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
        """
        Photon header parse (12 byte)
        - peerId: 2 byte
        - flags: 1 byte
        - commandCount: 1 byte
        - timestamp: 4 byte
        - challenge: 4 byte
        """
        self.peer_id = struct.unpack('>H', self.data[0:2])[0]
        self.flags = self.data[2]
        self.command_count = self.data[3]
        self.timestamp = struct.unpack('>I', self.data[4:8])[0]
        self.challenge = struct.unpack('>I', self.data[8:12])[0]
        self.pos = 12

    def parse_packet(self):
        """Paketi parse et"""
        self.parse_photon_header()

        for _ in range(self.command_count):
            command = self.parse_command()
            if command:
                self.commands.append(command)

    def parse_command(self) -> Optional[Dict]:
        """Photon command parse"""
        try:
            # Command header (12 byte)
            command_type = self.data[self.pos]
            channel_id = self.data[self.pos + 1]
            command_flags = self.data[self.pos + 2]
            # Skip 1 byte
            command_length = struct.unpack('>I', self.data[self.pos + 4:self.pos + 8])[0]
            sequence_number = struct.unpack('>I', self.data[self.pos + 8:self.pos + 12])[0]

            self.pos += 12

            # Command data
            command_data = self.data[self.pos:self.pos + command_length - 12]
            self.pos += command_length - 12

            # Parse command type
            if command_type == 6:  # Reliable Command
                return self.parse_reliable_command(command_data)
            elif command_type == 7:  # Unreliable Command
                # Skip 4 bytes
                return self.parse_reliable_command(command_data[4:])

        except Exception as e:
            print(f"Command parse error: {e}")
            return None

    def parse_reliable_command(self, data: bytes) -> Optional[Dict]:
        """Reliable command parse"""
        if len(data) < 2:
            return None

        # Skip 1 byte, read message type
        message_type = data[1]
        payload = data[2:]

        if message_type == 4:  # Event Data
            deserializer = Protocol16Deserializer(payload)
            return deserializer.deserialize_event_data()

        return None


# ============================================================================
# KULLANIM ÖRNEĞİ
# ============================================================================

def parse_photon_packet(raw_packet: bytes) -> Optional[List[Dict]]:
    """
    Ham Photon paketini parse et

    Returns:
        Event listesi veya None
    """
    try:
        packet = PhotonPacket(raw_packet)

        events = []
        for command in packet.commands:
            if command and 'code' in command:
                events.append(command)

        return events if events else None

    except Exception as e:
        print(f"Packet parse error: {e}")
        return None


if __name__ == "__main__":
    print("╔══════════════════════════════════════════════════╗")
    print("║   GERÇEK ZQRadar Photon Parser - Test          ║")
    print("╚══════════════════════════════════════════════════╝\n")

    print("Bu parser ZQRadar'ın kaynak kodundan çevrildi.")
    print("Kullanım:")
    print()
    print("  from zqradar_real_parser import parse_photon_packet")
    print()
    print("  # UDP port 5056'dan gelen paket")
    print("  packet_data = capture_udp_packet()")
    print()
    print("  # Parse et")
    print("  events = parse_photon_packet(packet_data)")
    print()
    print("  for event in events:")
    print("      if event['code'] == EventCodes.Move:")
    print("          posX = event['parameters'][4]")
    print("          posY = event['parameters'][5]")
    print("          print(f'Oyuncu pozisyonu: ({posX}, {posY})')")
    print()
    print("      elif event['code'] == EventCodes.NewHarvestableObject:")
    print("          # Kaynak spawn")
    print("          pass")
