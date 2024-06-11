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
    public partial class uye : Form
    {
        public uye()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        public void ekle()
        {
            if (maskedTextBox1.Text.Length != 11)
            {
                MessageBox.Show("11 Haneden fazla değer girmeyiniz");
            }
            else
            {
                OleDbCommand bakma = new OleDbCommand("select count(*) from kullanici where tc=@tc", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                bakma.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                if (Convert.ToInt32(bakma.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Bu kayıt veritabanında zaten var.");
                    baglanti.Close();

                }
                else
                {
                    try
                    {
                        if (maskedTextBox1.Text != "" && textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && maskedTextBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox2.Text != "")
                        {
                            OleDbCommand komut = new OleDbCommand("insert into kullanici(tc,adi_soyadi,cinsiyet,telefon,dogum_tarihi,ehliyet_no,sifre,g_sifre,cevap,email,yetki) values('" + maskedTextBox1.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + maskedTextBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox7.Text + "','" + textBox2.Text + "','müşteri')", baglanti);
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                            }
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Kayıt oldunuz");
                            baglanti.Close();
                            girisform frm = new girisform();
                            frm.Show();
                            this.Hide();
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
            }
        }
        public void temizle()
        {
            maskedTextBox1.Text = "";
            textBox1.Text = "";
            
            maskedTextBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length != 11)
            {
                MessageBox.Show("hata!!! TC numarası giriş Formatınız Yanlıştır.");
            }
            else
            {
                ekle();
                temizle();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            girisform home = new girisform();
            home.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
