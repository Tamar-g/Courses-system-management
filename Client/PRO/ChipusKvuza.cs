
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PRO.ServiceReference1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PRO.ServiceReference1;


namespace PRO
{
    public partial class ChipusKvuza : Form
    {
        List<Classes> Classes = new List<Classes>();
        List<string> L = new List<string>();
        List<courses> B = new List<courses>();
        List<Cities> Cities = new List<Cities>();
        public ChipusKvuza()
        {
            InitializeComponent();
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            L.Add("בנים");
            L.Add("בנות");
            B = Global.Sharat.GetAllCourses().ToList();
            Cities = Global.Sharat.Getallcities().ToList();
            //comboBox2.DataSource = Cities;
            //comboBox1.DataSource = B;
            //comboBox3.DataSource = L;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת יום לחיפוש קבוצה
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//הכנסת שעה עבור חיפוש קבוצה
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//הכנסת גיל לחיפוש קבוצה
        {

        }

        private void button3_Click(object sender, EventArgs e)//פתיחת קבוצה חדשה
        {
            this.Hide();
            AddKvuza w = new AddKvuza();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show(); ;
        }

        private void button6_Click(object sender, EventArgs e)//רישום לקבוצה קיימת
        {
            this.Hide();
            Rishum w = new Rishum();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button7_Click(object sender, EventArgs e)//עידכון קבוצה
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.Currentkvuza = Global.Sharat.findClassBycode(int.Parse(tz2));
            this.Hide();
            AddKvuza w = new AddKvuza();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
            Global.Currentkvuza = null;

        }

        private void button5_Click(object sender, EventArgs e)//מחיקת קבוצה
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.Currentkvuza = Global.Sharat.findClassBycode(int.Parse(tz2));
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את הקבוצה", "מחיקת קבוצה מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeletedClass(Global.Currentkvuza);
                    MessageBox.Show("הקבוצה נמחקה בהצלחה");
                    Global.Currentkvuza = null;
                    this.Hide();
                    ChipusChug w = new ChipusChug();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת הקבוצה");

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//פרטים אודות הקבוצה
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void ChipusKvuza_Load(object sender, EventArgs e)
        {
            Classes = Global.Sharat.GetallClasses().ToList();
            Cities = Global.Sharat.Getallcities().ToList();

            dataGridView2.DataSource = Classes;

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var TZ = textBox1.Text;
             this.Hide();
            var find = Classes.FirstOrDefault(st => st.NameClass.ToString() == TZ);
            if (find != null)
            {
                Global.Currentkvuza = find;


                ChipusKvuza a = new ChipusKvuza();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                AddKvuza w = new AddKvuza();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("הקבוצה אינה קיימת במערכת");

            }
            
         
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChipusChug w = new ChipusChug();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    //this.Hide();
        //    var city = Global.Sharat.Getallcities().FirstOrDefault(r => r.NameCity == comboBox2.Text).CodeCity;
        //    var TZ = comboBox1.Text;
        //    var find = Classes.FirstOrDefault(st => st.CourseCode.coursename.ToString() == TZ && st.Gender == comboBox3.Text && st.CodeCity.CodeCity == city);
        //    var b = comboBox2.Text;
        //    var findb = Cities.FirstOrDefault(st => st.CodeCity.ToString() == TZ);
        //    var c = comboBox3.Text;
        //}

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
