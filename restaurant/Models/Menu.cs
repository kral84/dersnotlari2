using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace restaurant.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string YemekAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
        public string Kategori { get; set; }
        public string Aciklama { get; set; }
    }
}
