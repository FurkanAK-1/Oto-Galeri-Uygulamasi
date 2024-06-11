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
using System.IO;

namespace otogaleriuygulamasyonu
{
    public partial class arac_islemleri : Form
    {
        public arac_islemleri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        DataTable dt = new DataTable();
        string DosyaYolu = "";

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
                dataGridView1.ClearSelection();
                listele.Dispose();
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                maskedTextBox1.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                pictureBox1.Image = null;
                DosyaYolu = "";
                


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                try
                {

                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    OleDbCommand sil = new OleDbCommand("delete from araclar where arac_id=" + dataGridView1.CurrentRow.Cells[0].Value + "", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Silme İşleminiz Başarılı");
                    doldur();
                    baglanti.Close();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand bakma = new OleDbCommand("select count(*) from araclar where plaka=@plaka", baglanti);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            bakma.Parameters.AddWithValue("@plaka", textBox1.Text);
            if (Convert.ToInt32(bakma.ExecuteScalar()) > 0)
            {
                MessageBox.Show("Bu plaka kullanılmaktadır!");
                baglanti.Close();

            }
            else
            {
                try
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && maskedTextBox1.Text != "" && comboBox2.Text != "" && textBox3.Text != "" && comboBox3.Text != "" && textBox7.Text != "")
                    {
                        OleDbCommand komut = new OleDbCommand("insert into araclar(plaka,marka,model,tip,renk,yıl,arac_durum,s_durum,fiyatı,resim) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + maskedTextBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox7.Text + "','" + Path.GetFileName(DosyaYolu) + "')", baglanti);


                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Ekleme İşleminiz Başarılı");

                        baglanti.Close();

                        doldur();
                    }
                    else
                    {
                        MessageBox.Show("Boş alan bırakmayınız!");
                    }
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            pictureBox1.ImageLocation = Application.StartupPath + "\\images\\" + dataGridView1.CurrentRow.Cells[10].Value.ToString();


        }

        private void arac_islemleri_Load(object sender, EventArgs e)
        {
            doldur();
            dataGridView1.AllowUserToAddRows = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Güncellemek İstediğiniz Veriyi Seçiniz");
            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox7.Text != "" && maskedTextBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    
                    OleDbCommand komut = new OleDbCommand("update araclar set plaka='" + textBox1.Text + "',fiyatı='" + textBox7.Text + "',marka='" + textBox2.Text + "',model='" + textBox3.Text + "',tip='" + textBox4.Text + "',renk='" + comboBox1.Text + "',yıl='" + maskedTextBox1.Text + "',arac_durum='" + comboBox2.Text + "',s_durum='" + comboBox3.Text + "',resim='" + Path.GetFileName(DosyaYolu) + "' where arac_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", baglanti);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                    doldur();
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız!");
                }
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From araclar where arac_id like'%" + textBox5.Text + "%'or plaka like '%" + textBox5.Text + "%'or marka like '%" + textBox5.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            girisform cu = new girisform();
            cu.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button12_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            
            dosya.ShowDialog();
             DosyaYolu = dosya.FileName;
            pictureBox1.ImageLocation = DosyaYolu;
        }
    }
}

