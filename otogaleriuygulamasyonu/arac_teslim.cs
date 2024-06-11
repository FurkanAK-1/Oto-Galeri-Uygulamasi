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
    public partial class arac_teslim : Form
    {
        public arac_teslim()
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
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from kiralama", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                listele.Dispose();


                baglanti.Close();

                textBox1.Text = "";




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

        private void arac_teslim_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Aracı Teslim Almayı Onaylıyor Musunuz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                try
                {
                    if (textBox1.Text != "")
                    {

                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        label2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        OleDbCommand sil = new OleDbCommand("delete from kiralama where kiralama_id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", baglanti);
                        sil.ExecuteNonQuery();

                        MessageBox.Show("Teslim Alma İşleminiz Başarılı");
                        doldur();
                        baglanti.Close();


                    }
                    else
                    {
                        MessageBox.Show("Boş Alan Bırakmayın!");
                    }
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


                    OleDbCommand guncelle = new OleDbCommand("update araclar set s_durum ='" + "Kiralık" + "'where arac_id=" + label2.Text + " ", baglanti);
                    guncelle.ExecuteNonQuery();


                    doldur();
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }



            }
            doldur();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            girisform cu = new girisform();
            cu.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

