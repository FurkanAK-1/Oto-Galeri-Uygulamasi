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
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        DataTable dt = new DataTable();
        void doldur()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();
            OleDbDataAdapter komut = new OleDbDataAdapter("Select * from kullanici where tc='" + maskedTextBox1.Text.ToString() +"'", baglanti);
            komut.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            maskedTextBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox1.Text = "";
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            musteriarac mc = new musteriarac();
            mc.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maskedTextBox1.Text))
                {
                    MessageBox.Show("Güncellemek İstediğiniz Veriyi Seçiniz");
                }
                else
                {

                    if (maskedTextBox1.Text != "" && textBox2.Text != "" && maskedTextBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                    {
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        OleDbCommand adtr = new OleDbCommand("UPDATE kullanici set adi_soyadi='" + textBox2.Text + "',cinsiyet='" + comboBox2.Text + "',telefon='" + maskedTextBox2.Text + "',dogum_tarihi='" + textBox5.Text + "',g_sifre='" + comboBox1.Text + "',cevap='" + textBox9.Text + "',sifre='" + textBox8.Text + "',email='" + textBox1.Text + "' where mst_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", baglanti);
                        adtr.ExecuteNonQuery();
                        
                        baglanti.Close();
                        MessageBox.Show("Güncelleme İşlemi Başarılı");
                        doldur();
                       
                    }
                    else
                    {
                        MessageBox.Show("Boş Alan Bırakamayınız!");
                    }

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Text = "";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker1.Value.ToShortDateString();
        }
    }
}
