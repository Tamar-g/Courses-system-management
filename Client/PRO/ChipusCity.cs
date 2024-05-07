using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRO.ServiceReference1;
using System.Windows.Forms;

namespace PRO
{
    public partial class ChipusCity : Form
    {
        List<Cities> Cities = new List<Cities>();
        List<Classes> Classes = new List<Classes>();
        public ChipusCity()
        {
            InitializeComponent();

            button7.Enabled = false;
            button8.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת עיר לחיפוש
        {

        }

        private void button3_Click(object sender, EventArgs e)//הוספת עיר חדשה
        {
            this.Hide();
            AddCity w = new AddCity();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();

        }

        private void button7_Click(object sender, EventArgs e)//עידכון העיר
        {

            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
        
            Global.CurrentCity=Global.Sharat.findCityByTZ(int.Parse(tz2));
            this.Hide();
            AddCity w = new AddCity();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
            Global.CurrentCity = null;


        }




        private void button8_Click(object sender, EventArgs e)//מחיקת העיר
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentCity=Global.Sharat.findCityByTZ(int.Parse(tz2));
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את העיר", "מחיקת עיר מן המערכת",
              MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeletedCity(Global.CurrentCity);
                    MessageBox.Show("העיר נמחקה בהצלחה");
                    Global.CurrentCity = null;
                    this.Hide();
                    ChipusCity w = new ChipusCity();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת המוצר");

                }

            }
        }

        private void button6_Click(object sender, EventArgs e)//פרטים אודות העיר
        {

        }

        private void ChipusCity_Load(object sender, EventArgs e)
        {
            Cities = Global.Sharat.Getallcities().ToList();
            dataGridView2.DataSource = Cities;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var TZ = textBox1.Text;
            //Global.Sharat.findCityByTZ(TZ);
            this.Hide();
            var find = Cities.FirstOrDefault(st => st.NameCity.ToString() == TZ);
            if (find != null)
            {
                Global.CurrentCity = find;
                AddCity a = new AddCity();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusCity w = new ChipusCity();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("העיר אינה קיימת במערכת");

            }

        }
        public void findCityByTZ(string DTZ)
        {


            this.Hide();
            var TZ = textBox1.Text;
            var find = Cities.FirstOrDefault(st => st.NameCity.ToString() == TZ);
            if (find != null)
            {
                Global.CurrentCity = find;
                AddCity a = new AddCity();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusCity w = new ChipusCity();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("העיר אינה קיימת במערכת");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NetuneyMaharechet1 w = new NetuneyMaharechet1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

            button7.Enabled = true;
            button8.Enabled = true;

        }
    }
}
