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
using System.Net.Mail;

namespace otogaleriuygulamasyonu
{
    public partial class sifirla : Form
    {
        public sifirla()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        public bool Gonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("trabzonotogaleri@gmail.com");
            
            ePosta.To.Add(textBox2.Text);
            ;

            ePosta.Subject = konu; 
            
            ePosta.Body = ("Hesabınızın Şifresi : " + icerik);  
            
            SmtpClient smtp = new SmtpClient();
            
            smtp.Credentials = new System.Net.NetworkCredential("trabzonotogaleri@gmail.com", "tsotogaleri61");
            
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text.Length != 11)
                {
                    MessageBox.Show("11 Haneden fazla değer girmeyiniz");
                }
                else
                {
                    if (maskedTextBox1.Text != "" && textBox2.Text != "")
                    {


                        OleDbCommand komut = new OleDbCommand("Select * from kullanici where tc='" + maskedTextBox1.Text.ToString() + "'and email='" + textBox2.Text.ToString() + "'", baglantim);
                        if (baglantim.State == ConnectionState.Closed)
                        {
                            baglantim.Open();
                        }
                        OleDbDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            string sifre = oku["sifre"].ToString();
                                       
                            MessageBox.Show("Girmiş Oldunuz Bilgiler Uyuşuyor Şifreniz Mail adresinize yollanıyor");
                            Gonder("Unutmuş Olduğunuz Şifreniz Ektedir", sifre);
                            
                            maskedTextBox1.Text = "";
                            textBox2.Text = "";
                            comboBox1.SelectedIndex = -1;

                            baglantim.Close();
                        }
                        else
                        {
                            MessageBox.Show("Hatalı Bilgiler");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Boş Alan Bırakmayınız!");
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            girisform home = new girisform();
            home.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
            label1.Visible = false;
            maskedTextBox1.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
           
            maskedTextBox1.Enabled = false;
            textBox2.Enabled = false;

            button1.Visible = false;
            button1.Enabled = false;
            linkLabel1.Visible = false;
            linkLabel1.Enabled = false;

            label6.Visible = true;
            maskedTextBox2.Visible = true;
            textBox1.Visible = true;
            textBox3.Visible = true;
            label5.Visible = true;
            comboBox1.Visible = true;
            label2.Visible = true;
           
            maskedTextBox2.Enabled = true;
            label4.Visible = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            button8.Visible = true;
            button8.Enabled = true;
            linkLabel2.Visible = true;
            linkLabel2.Enabled = true;

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {



                if (maskedTextBox2.Text.Length != 11)
                {
                    MessageBox.Show("11 Haneden fazla değer girmeyiniz");
                }
                else
                {
                    if (maskedTextBox2.Text != "" && textBox1.Text != "")
                    {


                        OleDbCommand komut = new OleDbCommand("select * from kullanici where tc='" + maskedTextBox2.Text + "'and g_sifre='" + comboBox1.Text + "'and cevap='" + textBox1.Text + "'", baglantim);
                        if (baglantim.State == ConnectionState.Closed)
                        {
                            baglantim.Open();
                        }
                        OleDbDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            textBox3.Text = oku["sifre"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Hatalı Bilgiler");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Boş Alan Bırakmayınız!");
                    }
                    baglantim.Close();
                }
                maskedTextBox2.Text = "";
                textBox1.Text = "";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
            label6.Visible = false;
            maskedTextBox2.Visible = false;
            textBox1.Visible = false;
            textBox3.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            label2.Visible = false;
            
            maskedTextBox2.Enabled = false;
            label4.Visible = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            button8.Visible = false;
            button8.Enabled = false;
            linkLabel2.Visible = false;
            linkLabel2.Enabled = false;


            label1.Visible = true;
            maskedTextBox1.Visible = true;
            textBox2.Visible = true;
            label3.Visible = true;
           
            maskedTextBox1.Enabled = true;
            textBox2.Enabled = true;
            button1.Visible = true;
            button1.Enabled = true;
            linkLabel1.Visible = true;
            linkLabel1.Enabled = true;
        }

        private void Sifirla_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
            label6.Visible = false;
            maskedTextBox2.Visible = false;
            textBox1.Visible = false;
            textBox3.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            label2.Visible = false;
           
            maskedTextBox2.Enabled = false;
            label4.Visible = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            button8.Visible = false;
            button8.Enabled = false;
            linkLabel2.Visible = false;
            linkLabel2.Enabled = false;
        }
    }
}
