using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace otogaleriuygulamasyonu
{
    public partial class girisform : Form
    {
        public girisform()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    OleDbCommand komut = new OleDbCommand("select * from kullanici where (tc='" + textBox1.Text + "' or adi_soyadi='" + textBox1.Text + "') and sifre ='" + textBox2.Text + "'", baglantim);
                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();
                    }
                    OleDbDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        if (oku["yetki"].ToString() == "müşteri")
                        {

                            MessageBox.Show("Giriş Başarılı!");

                            musteriarac a = new musteriarac();
                            a.Show();
                            this.Hide();
                        }
                        else if (oku["yetki"].ToString() == "admin")
                        {
                            MessageBox.Show("Giriş Başarılı!");
                            menu a = new menu();
                            a.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Başarısız");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
                    }
                    baglantim.Close();
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uye uye = new uye();
            uye.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifirla sifirla = new sifirla();
            sifirla.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
