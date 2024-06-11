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
using System.Net;

namespace otogaleriuygulamasyonu
{
    public partial class dogrulama : Form
    {
        public dogrulama()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        DataTable dt = new DataTable();

        private void Button1_Click(object sender, EventArgs e)
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


                        OleDbCommand komut = new OleDbCommand("Select * from kullanici where tc='" + maskedTextBox1.Text.ToString() + "'and sifre='" + textBox2.Text.ToString() + "'", baglantim);
                        if (baglantim.State == ConnectionState.Closed)
                        {
                            baglantim.Open();
                        }
                        OleDbDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {

                            MessageBox.Show("Girmiş Oldunuz Bilgiler Doğru");




                            doldur();
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

        private void Dogrulama_Load(object sender, EventArgs e)
        {

            button4.Enabled = true;
            button4.Visible = true;
            button7.Enabled = true;
            button7.Visible = true;
        }

        void doldur()
        {
            try
            {

                guncelle gc = new guncelle();
                if (baglantim.State == ConnectionState.Closed)
                {
                    baglantim.Open();
                }
                dt.Clear();
                OleDbDataAdapter komut = new OleDbDataAdapter("Select * from kullanici where tc='" + maskedTextBox1.Text.ToString() + "'and sifre='" + textBox2.Text.ToString() + "'", baglantim);
                komut.Fill(dt);
                gc.dataGridView1.DataSource = dt;
                gc.dataGridView1.ClearSelection();
                gc.Show();
                this.Hide();
                baglantim.Close();







            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            maskedTextBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            maskedTextBox1.Enabled = true;
            textBox2.Enabled = true;
            button1.Enabled = true;

            button4.Enabled = true;
            button4.Visible = true;
            button7.Enabled = true;
            button7.Visible = true;


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            musteriarac home = new musteriarac();
            home.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }


    }
}
