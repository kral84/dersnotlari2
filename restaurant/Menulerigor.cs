using restaurant.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace restaurant
{
    public partial class Menulerigor : Form
    {
        public List<restaurant.Models.Menu> tumMenuler;

        public Menulerigor()
        {
            InitializeComponent();
            this.Load += Menulerigor_Load;
        }

        private void Menulerigor_Load(object sender, EventArgs e)
        {
            using (var db = new RestaurantDbContext())
            {
                tumMenuler = db.Set<restaurant.Models.Menu>().ToList();
                Menus.DataSource = tumMenuler;
                Menus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void AnaYemek_Click(object sender, EventArgs e)
        {
            var anaYemekler = tumMenuler.Where(m => m.Kategori == "Ana Yemek").ToList();
            Menus.DataSource = anaYemekler;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Corba_Click(object sender, EventArgs e)
        {
            var corbalar = tumMenuler.Where(m => m.Kategori == "Çorba").ToList();
            Menus.DataSource = corbalar;
        }
        private void Icecek_Click(object sender, EventArgs e)
        {
            var icecekler = tumMenuler.Where(m => m.Kategori == "İçecek").ToList();
            Menus.DataSource = icecekler;
        }       
        private void Hepsi_Click(object sender, EventArgs e)
        {
            Menus.DataSource = tumMenuler;
        }

        private void Tatli_Click_1(object sender, EventArgs e)
        {
            var tatlilar = tumMenuler.Where(m => m.Kategori == "Tatlı").ToList();
            Menus.DataSource = tatlilar;
        }

        private void Icecek_Click_1(object sender, EventArgs e)
        {
            var icecekler = tumMenuler.Where(m => m.Kategori == "İçecek").ToList();
            Menus.DataSource = icecekler;
        }

        private void Ara_Sıcak_Click(object sender, EventArgs e)
        {
            var araSicaklar = tumMenuler.Where(m => m.Kategori == "Ara Sıcak").ToList();
            Menus.DataSource = araSicaklar;
        }

        private void Hepsi_Click_1(object sender, EventArgs e)
        {
            Menus.DataSource = tumMenuler;
        }

        private void Geri_don_Click(object sender, EventArgs e)
        {
            Form1 Anasayfa = new Form1();
            Anasayfa.Show();
            this.Close();
        }
    }
}