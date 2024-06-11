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
    public partial class musteri_islemleri : Form
    {
        public musteri_islemleri()
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
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from kullanici where yetki='müşteri'", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                listele.Dispose();
                baglanti.Close();
                maskedTextBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox2.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;


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

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length != 11)
            {
                MessageBox.Show("hata!!! TC numarası giriş Formatınız Yanlıştır.");
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
                    MessageBox.Show("Bu TC numarası üzerine zaten kayıt var.");
                    maskedTextBox1.Text = "";
                    textBox2.Text = "";
                    maskedTextBox2.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    baglanti.Close();

                }
                else
                {

                    try
                    {
                        if (maskedTextBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && maskedTextBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "" && comboBox1.Text != "" && textBox9.Text != ""  && textBox1.Text != "" && comboBox3.Text != "")
                        {
                            OleDbCommand komut = new OleDbCommand("insert into kullanici(tc,adi_soyadi,cinsiyet,telefon,dogum_tarihi,ehliyet_no,sifre,g_sifre,cevap,email,yetki) values('" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + maskedTextBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "','" + textBox1.Text + "','" + comboBox3.Text + "')", baglanti);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
            comboBox3.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

        }

        private void musteri_islemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            doldur();
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

                    OleDbCommand sil = new OleDbCommand("delete from kullanici where mst_id=" + dataGridView1.CurrentRow.Cells[0].Value + "", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Silme İşleminiz Başarılı");
                    doldur();
                    baglanti.Close();

                }
                catch
                {


                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                        OleDbCommand adtr = new OleDbCommand("UPDATE kullanici set tc='" + maskedTextBox1.Text + "',adi_soyadi='" + textBox2.Text + "',cinsiyet='" + comboBox2.Text + "',telefon='" + maskedTextBox2.Text + "',dogum_tarihi='" + textBox5.Text + "',ehliyet_no='" + textBox6.Text + "',g_sifre='" + comboBox1.Text + "',cevap='" + textBox9.Text + "',sifre='" + textBox8.Text + "',email='" + textBox1.Text + "',yetki='" + comboBox3.Text + "' where mst_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", baglanti);
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
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kullanici where tc like'%" + textBox7.Text + "%'or adi_soyadi like '%" + textBox7.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();
            baglanti.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            girisform cu = new girisform();
            cu.Show();
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

        private void button9_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}


