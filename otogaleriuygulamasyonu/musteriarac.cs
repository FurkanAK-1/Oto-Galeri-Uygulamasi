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
    public partial class musteriarac : Form
    {
        public musteriarac()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        DataTable dt = new DataTable();

        void doldur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from araclar", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        void uygunaracdoldur()
        {
            try
            {

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                dt.Clear();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from araclar where s_durum='" + "Satışa Uygun" + "'", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();

                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        void uygunaracdoldur2()
        {


            try
            {

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                dt.Clear();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from araclar where s_durum='" + "Kiralık" + "'", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();

                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            label11.Visible = false;
            label15.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label11.Visible = false;
            textBox13.Visible = false;
            textBox12.Visible = false;
            textBox11.Visible = false;
            label12.Visible = true;
            textBox10.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox14.Visible = true;
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            label11.Visible = false;
            label15.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label12.Visible = true;
            label11.Visible = false;
            textBox13.Visible = false;
            textBox12.Visible = false;
            textBox11.Visible = false;
            textBox10.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox14.Visible = true;
            uygunaracdoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            label11.Visible = true;
            label15.Visible = true;
            label14.Visible = true;
            label13.Visible = true;
            label11.Visible = true;
            textBox13.Visible = true;
            textBox12.Visible = true;
            textBox11.Visible = true;
            textBox10.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            textBox14.Visible = false;
            label12.Visible = false;
            uygunaracdoldur2();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pictureBox1.ImageLocation = Application.StartupPath + "\\images\\" + dataGridView1.CurrentRow.Cells[10].Value.ToString();




        }

        private void musteriarac_Load(object sender, EventArgs e)
        {
            label11.Visible = false;
            label15.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label11.Visible = false;
            textBox13.Visible = false;
            textBox12.Visible = false;
            textBox11.Visible = false;
            textBox10.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button5.Visible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From araclar where plaka like'%" + textBox6.Text + "%'or marka like '%" + textBox6.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox13.Text == textBox12.Text && textBox13.Text!="" && textBox12.Text!="")
            {
                textBox10.Text = textBox11.Text;
            }
            else
            {
                if (textBox13.Text != "" && textBox12.Text != "" && textBox11.Text != "")
                {
                    DateTime bTarih = Convert.ToDateTime(dateTimePicker1.Text);
                    DateTime kTarih = Convert.ToDateTime(dateTimePicker2.Text);
                    TimeSpan Sonuc = kTarih - bTarih;
                    if (kTarih >= bTarih)
                    {
                        double a = Convert.ToDouble(textBox11.Text);
                        double b = Convert.ToDouble(Sonuc.TotalDays.ToString());
                        textBox10.Text = (a * b).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Tarih Girdiniz!");
                    }
                }


                else
                {
                    MessageBox.Show("Hata!");
                }
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox13.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox12.Text = dateTimePicker2.Value.ToShortDateString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            girisform cu = new girisform();
            cu.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            dogrulama dogrula = new dogrulama();
            dogrula.Show();
            this.Hide();
            
        }
    }
}
