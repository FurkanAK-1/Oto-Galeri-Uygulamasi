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
    public partial class arac_satis : Form
    {
        public arac_satis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\otouygulama.accdb");
        DataTable dt = new DataTable();
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
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from arac_satis", baglanti);
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
                textBox6.Text = "";



            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
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
                dataGridView2.ClearSelection();
                listele2.Dispose();




                baglanti.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
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
                OleDbDataAdapter listele3 = new OleDbDataAdapter("select * from araclar where s_durum='" + "Satışa Uygun" + "'", baglanti);
                listele3.Fill(dt2);
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                listele3.Dispose();




                baglanti.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void arac_satis_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            doldur();
            doldur2();
            doldur3();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand bakma = new OleDbCommand("select count(*) from arac_satis where arac_id=@arac_id", baglanti);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            bakma.Parameters.AddWithValue("@arac_id", textBox6.Text);
            if (Convert.ToInt32(bakma.ExecuteScalar()) > 0)
            {
                MessageBox.Show("Bu araç satılmıştır!");
                baglanti.Close();

            }
            else
            {
                try
                {
                    if (textBox5.Text != "" && textBox6.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                    {
                        OleDbCommand komut = new OleDbCommand("insert into arac_satis(mst_id,arac_id,alis_tarihi,veris_tarihi,ucret) values(" + textBox5.Text + "," + textBox6.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);
                        //
                        // 
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


                            OleDbCommand guncelle = new OleDbCommand("update araclar set s_durum ='" + "Satıldı" + "'where arac_id=" + textBox6.Text + " ", baglanti);
                            guncelle.ExecuteNonQuery();


                            doldur();
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show(hata.Message);
                        }
                        MessageBox.Show("Satış İşleminiz Başarılı");
                        baglanti.Close();

                        doldur();
                        doldur3();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
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
                    label1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    OleDbCommand sil = new OleDbCommand("delete from arac_satis where satis_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", baglanti);
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


                    OleDbCommand guncelle = new OleDbCommand("update araclar set s_durum ='" + "Satışa Uygun" + "'where arac_id=" + label1.Text + " ", baglanti);
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
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox3.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
                textBox2.Text = dateTimePicker2.Value.ToShortDateString();
           
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
                textBox1.Text = dateTimePicker1.Value.ToShortDateString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Güncellemek İstediğiniz Veriyi Seçiniz");
            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    if (textBox5.Text == dataGridView1.CurrentRow.Cells[2].Value.ToString() && textBox6.Text == dataGridView1.CurrentRow.Cells[1].Value.ToString())
                    {
                        OleDbCommand komut = new OleDbCommand("update arac_satis set alis_tarihi='" + textBox1.Text + "',veris_tarihi='" + textBox2.Text + "',ucret='" + textBox3.Text + "' where satis_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " and mst_id=" + textBox5.Text + " and arac_id=" + textBox6.Text + "", baglanti);

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
                    MessageBox.Show("Boş Alan Bırakmayınız");
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From arac_satis where satis_id like'%" + textBox4.Text + "%'or arac_id like '%" + textBox4.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();
            baglanti.Close();
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt1.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kullanici where tc like'%" + textBox7.Text + "%'or mst_id like '%" + textBox7.Text + "%' or adi_soyadi like '%" + textBox7.Text + "%'", baglanti);
            adtr.Fill(dt1);
            dataGridView2.DataSource = dt1;
            adtr.Dispose();
            baglanti.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            {
                baglanti.Open();
            }
            dt2.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From araclar where arac_id like'%" + textBox8.Text + "%'or plaka like '%" + textBox8.Text + "%'or marka like '%" + textBox8.Text + "%'", baglanti);
            adtr.Fill(dt2);
            dataGridView3.DataSource = dt2;
            adtr.Dispose();
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

