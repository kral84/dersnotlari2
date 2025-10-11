using restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace restaurant.Helpers
{
    public class SiparisIslemleri
    {
   
        public static bool SiparisEkle(int masaNo, int menuId, int adet)
        {
            using (var db = new RestaurantDbContext())
            {
          
                var menu = db.Set<restaurant.Models.Menu>().FirstOrDefault(m => m.Id == menuId);
                if (menu == null || menu.Stok < adet)
                {
                    return false;
                }
            
                var yeniSiparis = new Siparis
                {
                    MasaNo = masaNo,
                    MenuId = menuId,
                    Adet = adet,
                    ToplamFiyat = menu.Fiyat * adet,
                    Tarih = DateTime.Now
                };
                db.Siparisler.Add(yeniSiparis);
           
                menu.Stok -= adet;
                db.SaveChanges();
                return true;
            }
        }

        public static List<object> MasaSiparisleriDetayGetir(int masaNo)
        {
            using (var db = new RestaurantDbContext())
            {
                var siparisler = (from s in db.Siparisler
                                  join m in db.Set<restaurant.Models.Menu>() on s.MenuId equals m.Id
                                  where s.MasaNo == masaNo
                                  select new
                                  {
                                      YemekAdi = m.YemekAdi,
                                      Adet = s.Adet,
                                      BirimFiyat = m.Fiyat,
                                      ToplamFiyat = s.ToplamFiyat
                                  }).ToList<object>();
                return siparisler;
            }
        }

   
        public static decimal MasaHesabiHesapla(int masaNo)
        {
            using (var db = new RestaurantDbContext())
            {
                var toplam = db.Siparisler
                    .Where(s => s.MasaNo == masaNo)
                    .Sum(s => (decimal?)s.ToplamFiyat) ?? 0;
                return toplam;
            }
        }

    
        public static bool SiparisSil(int siparisId)
        {
            using (var db = new RestaurantDbContext())
            {
                var siparis = db.Siparisler.FirstOrDefault(s => s.Id == siparisId);
                if (siparis != null)
                {
                 
                    var menu = db.Set<restaurant.Models.Menu>().FirstOrDefault(m => m.Id == siparis.MenuId);
                    if (menu != null)
                    {
                        menu.Stok += siparis.Adet;
                    }
                    db.Siparisler.Remove(siparis);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    
        public static bool MasaSiparisleriniTemizle(int masaNo)
        {
            using (var db = new RestaurantDbContext())
            {
                var siparisler = db.Siparisler.Where(s => s.MasaNo == masaNo).ToList();
                db.Siparisler.RemoveRange(siparisler);
                db.SaveChanges();
                return true;
            }
        }
    }
}