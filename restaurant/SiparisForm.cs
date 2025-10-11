using restaurant.Helpers;
using restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace restaurant
{
    public partial class SiparisForm : Form
    {
        private int masaNo;

        public SiparisForm(int masaNumarasi)
        {
            InitializeComponent();
            masaNo = masaNumarasi;
            this.Load += SiparisForm_Load;
        }

        private void SiparisForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Sipariş - Masa {masaNo}";
            label1.Text = $"Masa: {masaNo}";
            MenuleriYukle();
            SiparisleriYukle();
        }

        private void MenuleriYukle()
        {
            using (var db = new RestaurantDbContext())
            {
                var menuler = db.Set<restaurant.Models.Menu>().Where(m => m.Stok > 0).ToList();
                dataGridView1.DataSource = menuler;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void SiparisleriYukle()
        {
            var siparisler = SiparisIslemleri.MasaSiparisleriDetayGetir(masaNo);
            dataGridView2.DataSource = siparisler;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            decimal toplam = SiparisIslemleri.MasaHesabiHesapla(masaNo);
            label6.Text = $"Toplam: {toplam:C2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen menüden bir yemek seçin!");
                return;
            }

         
            int menuId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

          
            if (!int.TryParse(textBox2.Text, out int adet) || adet <= 0)
            {
                MessageBox.Show("Geçerli bir adet girin!");
                return;
            }

        
            if (SiparisIslemleri.SiparisEkle(masaNo, menuId, adet))
            {
                MessageBox.Show("✅ Sipariş eklendi!");
                MenuleriYukle();      
                SiparisleriYukle();   
                textBox2.Clear();    
            }
            else
            {
                MessageBox.Show("❌ Stok yetersiz veya hata oluştu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal toplam = SiparisIslemleri.MasaHesabiHesapla(masaNo);

         
            if (toplam == 0)
            {
                MessageBox.Show("Henüz sipariş verilmemiş!");
                return;
            }

           
            var result = MessageBox.Show(
                $"Toplam tutar: {toplam:C2}\n\nÖdeme alındı mı?",
                "Hesap Kapat",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
                SiparisIslemleri.MasaSiparisleriniTemizle(masaNo);

 

                MessageBox.Show("✅ Ödeme Alındı...\nTeşekkürler!");
                Form1 anasayfa = new Form1();
                anasayfa.Show();
                this.Close();
            }
        }

      
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}