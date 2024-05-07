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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//הפנייה למערכת שעות
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//הפנייה לחוגים-מה זה אומר???ץ
        {
            this.Hide();
            ChipusChug CIC=new ChipusChug();
            CIC.FormClosed +=(s,ccc)=>this.Close();
            CIC.Show();
        }

        private void button3_Click(object sender, EventArgs e)//הפנייה ללקוחות-מה זה אומר???ץ
        {
            {
                this.Hide();
                ChipusStundent w = new ChipusStundent();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
            }

            //private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            //private void pictureBox1_Click_1(object sender, EventArgs e)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)//הפניה לנתוני מערכת
        {
            this.Hide();
            NetuneyMaharechet1 w = new NetuneyMaharechet1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ayala w = new ayala();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();

        }
    }
}
