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
    public partial class arac_kiralama : Form
    {
        public arac_kiralama()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        DataTable dt = new DataTable();dfgdf
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        void doldur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from kiralama", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.ClearSelection();

                baglanti.Close();


                textBox3.Text = "";
                textBox4.Text = "";



            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
        void doldur2()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt1.Clear();
                OleDbDataAdapter listele2 = new OleDbDataAdapter("select mst_id,tc,adi_soyadi,cinsiyet,telefon,dogum_tarihi,ehliyet_no from kullanici where yetki='müşteri'", baglanti);
                
                listele2.Fill(dt1);
                dataGridView2.DataSource = dt1;
                listele2.Dispose();
                dataGridView2.ClearSelection();



                baglanti.Close();




            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        void doldur3()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt2.Clear();
                OleDbDataAdapter listele3 = new OleDbDataAdapter("select * from araclar where s_durum='" + "Kiralık" + "'", baglanti);
                listele3.Fill(dt2);
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                listele3.Dispose();




                baglanti.Close();




            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand bakma = new OleDbCommand("select count(*) from kiralama where arac_id=@arac_id", baglanti);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            bakma.Parameters.AddWithValue("@arac_id", textBox2.Text);
            if (Convert.ToInt32(bakma.ExecuteScalar()) > 0)
            {
                MessageBox.Show("Bu araç kiralanmıştır!");
                baglanti.Close();

            }

            else
            {
                try
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                    {
                        OleDbCommand komut = new OleDbCommand("insert into kiralama(mst_id,arac_id,alis_tarihi,satis_tarihi,ucret,total) values(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglanti);


                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }

                        komut.ExecuteNonQuery();

                        try
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                            }


                            OleDbCommand guncelle = new OleDbCommand("update araclar set s_durum ='" + "Kiralandı" + "'where arac_id=" + textBox2.Text + " ", baglanti);
                            guncelle.ExecuteNonQuery();


                            doldur();
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show(hata.Message);
                        }
                        MessageBox.Show("Kiralama İşleminiz Başarılı");
                        baglanti.Close();

                        doldur();
                        doldur3();
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

        private void arac_kiralama_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            doldur();
            doldur2();
            doldur3();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
          
                textBox4.Text = dateTimePicker2.Value.ToShortDateString();
           
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
                    label6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    OleDbCommand sil = new OleDbCommand("delete from kiralama where kiralama_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", baglanti);
                    sil.ExecuteNonQuery();

                    MessageBox.Show("Silme İşleminiz Başarılı");
                    doldur();
                    baglanti.Close();


                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }


                    OleDbCommand guncelle = new OleDbCommand("update araclar set s_durum ='" + "Kiralık" + "'where arac_id=" + label6.Text + " ", baglanti);
                    guncelle.ExecuteNonQuery();


                    doldur();
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }



            }
            doldur();
            doldur3();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Güncellemek İstediğiniz Veriyi Seçiniz");
            }
            else
            {
                
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""  )
                {
                    if (textBox1.Text == dataGridView1.CurrentRow.Cells[2].Value.ToString() && textBox2.Text == dataGridView1.CurrentRow.Cells[1].Value.ToString())
                    {
                        OleDbCommand komut = new OleDbCommand("update kiralama set alis_tarihi='" + textBox3.Text + "',satis_tarihi='" + textBox4.Text + "',total='" + textBox6.Text + "' where kiralama_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "and mst_id="+textBox1.Text+" and arac_id="+textBox2.Text+"", baglanti);

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
                        MessageBox.Show("Yanlış Seçim");
                    }
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız!");
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kiralama where kiralama_id like'%" + textBox7.Text + "%'or arac_id like '%" + textBox7.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text==textBox4.Text && textBox3.Text!="" && textBox4.Text!="")
            {
                textBox6.Text = textBox5.Text;
            }
            else
            {
                if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    DateTime bTarih = Convert.ToDateTime(dateTimePicker1.Text);
                    DateTime kTarih = Convert.ToDateTime(dateTimePicker2.Text);
                    TimeSpan Sonuc = kTarih - bTarih;
                    if (kTarih >= bTarih)
                    {
                        double a = Convert.ToDouble(textBox5.Text);
                        double b = Convert.ToDouble(Sonuc.TotalDays.ToString());
                        textBox6.Text = (a * b).ToString();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            girisform cu = new girisform();
            cu.Show();
            this.Hide();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt1.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kullanici where tc like'%" + textBox8.Text + "%'or mst_id like '%" + textBox8.Text + "%' or adi_soyadi like '%" + textBox8.Text + "%'", baglanti);
            adtr.Fill(dt1);
            dataGridView2.DataSource = dt1;
            adtr.Dispose();
            baglanti.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt2.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From araclar where arac_id like'%" + textBox9.Text + "%'or plaka like '%" + textBox9.Text + "%'or marka like '%" + textBox9.Text + "%'", baglanti);
            adtr.Fill(dt2);
            dataGridView3.DataSource = dt2;
            adtr.Dispose();
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


