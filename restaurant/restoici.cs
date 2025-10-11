using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using restaurant.Helpers;
using restaurant.Models;

namespace restaurant
{
    public partial class restoici : Form
    {
        public restoici()
        {
            InitializeComponent();
            this.Load += restoici_Load;
        }

        private void restoici_Load(object sender, EventArgs e)
        {
           
            MasalariYukle();
        }

        private void MasalariYukle()
        {
            var masalar = MasaIslemleri.TumMasalariGetir();
            dataGridView1.DataSource = masalar;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void masabul_Click(object sender, EventArgs e)
        {
         
            if (!int.TryParse(textBox1.Text, out int kisiSayisi) || kisiSayisi <= 0)
            {
                MessageBox.Show("Geçerli bir kişi sayısı girin!");
                return;
            }

          
            var uygunMasa = MasaIslemleri.UygunMasaBul(kisiSayisi);

            if (uygunMasa != null)
            {
             
                MasaIslemleri.MasayiDoluYap(uygunMasa.MasaNo);

                MessageBox.Show($"Masa {uygunMasa.MasaNo} atandı! ({uygunMasa.KisiSayisi} kişilik)");

                SiparisForm siparisForm = new SiparisForm(uygunMasa.MasaNo);
                siparisForm.Show();

              
                MasalariYukle();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show($"{kisiSayisi} kişilik uygun boş masa yok!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}