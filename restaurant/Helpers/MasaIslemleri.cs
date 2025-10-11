using restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace restaurant.Helpers
{
    public class MasaIslemleri
    {
     
        public static List<Masa> TumMasalariGetir()
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Masalar.ToList();
            }
        }

    
        public static Masa UygunMasaBul(int kisiSayisi)
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Masalar
                    .Where(m => m.Durum == "Boş" && m.KisiSayisi >= kisiSayisi)
                    .OrderBy(m => m.KisiSayisi)
                    .FirstOrDefault();
            }
        }

   
        public static bool MasayiDoluYap(int masaNo)
        {
            using (var db = new RestaurantDbContext())
            {
                var masa = db.Masalar.FirstOrDefault(m => m.MasaNo == masaNo);
                if (masa != null && masa.Durum == "Boş")
                {
                    masa.Durum = "Dolu";
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

     
        public static bool MasayiBosalt(int masaNo)
        {
            using (var db = new RestaurantDbContext())
            {
                var masa = db.Masalar.FirstOrDefault(m => m.MasaNo == masaNo);
                if (masa != null && masa.Durum == "Dolu")
                {
                    masa.Durum = "Boş";
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}