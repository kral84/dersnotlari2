using System;

namespace restaurant.Models
{
    public partial class Siparis
    {
        public int Id { get; set; }
        public int MasaNo { get; set; }
        public int MenuId { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; }
    }
}