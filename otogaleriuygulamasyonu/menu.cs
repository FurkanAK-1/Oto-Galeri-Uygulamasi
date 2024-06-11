using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otogaleriuygulamasyonu
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arac_satis satis = new arac_satis();
            satis.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            arac_islemleri arac = new arac_islemleri();
            arac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_islemleri musteri = new musteri_islemleri();
            musteri.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            arac_kiralama kira = new arac_kiralama();
            kira.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arac_teslim teslim = new arac_teslim();
            teslim.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            girisform cu = new girisform();
            cu.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
