using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using restaurant.Models;

namespace restaurant
{
    public partial class yöneticigiris : Form
    {
        public yöneticigiris()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Geri_don_Click(object sender, EventArgs e)
        {
            Form1 Anasayfa = new Form1();
            Anasayfa.Show();
            this.Close();
        }

        private void giris_Click(object sender, EventArgs e)
        {
            if (kullanıciadi.Text != "" && sifre.Text != "")
            {
               
                using (var db = new RestaurantDbContext())
                {
                    var yonetici = db.Yoneticiler
                        .FirstOrDefault(y => y.KullaniciAdi == kullanıciadi.Text && y.Sifre == sifre.Text);

                    if (yonetici != null)
                    {
                        MessageBox.Show("Giriş başarılı!");
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Boş bırakılamaz.", "Hata boş bıraktın.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}