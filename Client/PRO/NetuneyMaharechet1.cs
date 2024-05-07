using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRO.ServiceReference1;

namespace PRO
{
    public partial class NetuneyMaharechet1 : Form
    {
        public NetuneyMaharechet1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//הפנייה לחדרים
        {

        }

        private void button1_Click(object sender, EventArgs e)//הפנייה לצוות
        {
            this.Hide();
            ChipusTeacher w = new ChipusTeacher();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button2_Click(object sender, EventArgs e)//הפניה לערים
        {
            this.Hide();
            ChipusCity w = new ChipusCity();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button3_Click(object sender, EventArgs e)//הפניה לציוד
        {

        }

        private void NetuneyMaharechet1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChipusMuzar w = new ChipusMuzar();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }
    }
}
