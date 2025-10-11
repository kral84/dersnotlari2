namespace restaurant.Models
{
    public class Masa
    {
        public int Id { get; set; }
        public int MasaNo { get; set; }
        public string Durum { get; set; }  // "Boş" veya "Dolu"
        public int KisiSayisi { get; set; }
    }
}