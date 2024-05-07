using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRO.ServiceReference1;

namespace PRO
{
    public partial class AddChug : Form
    {
        List<courses> coursim = new List<courses>();

        public AddChug()
        {
            InitializeComponent();
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת שם חוג
        {
            label11.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) /*הכנסת קוד חוג*/
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//אישור הוספת החוג
        {
            if (label11.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיים חוג בשם זה.");
            }
            else
            {
                courses s = new courses { coursename = nameChug.Text };


                s.CourseCode = Global.Sharat.GetCodeToCourse();
                var w = Global.Sharat.AddCourse(s);
                if (w == 0)
                {
                    MessageBox.Show("שגיאה בהוספת החוג");


                }
                else
                {
                    MessageBox.Show("החוג נוסף בהצלחה");



                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChipusChug w = new ChipusChug();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label11.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיים חוג בשם זה.");
            }
            else
            {

                //לאסוף מחדש את כל הפרטים 
                Global.CurrentChug.coursename = nameChug.Text;
                var res = Global.Sharat.UpDateCourse(Global.CurrentChug);
                MessageBox.Show("החוג עודכן בהצלחה");
                Global.CurrentChug = null;
                this.Hide();
                ChipusChug w = new ChipusChug();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
            }

        }
        private void AddChug_Load(object sender, EventArgs e)
        {
            if (Global.CurrentChug != null)
            {
                button4.Visible = true;
                button1.Visible = false;


                nameChug.Text = Global.CurrentChug.coursename;

            }
            else
            {
                button4.Visible = false;
                button1.Visible = true;
            }
        }

        private void AddChug_Load_1(object sender, EventArgs e)
        {
            coursim = Global.Sharat.GetAllCourses().ToList();
            label11.Visible = false;
            if (Global.CurrentChug != null)//אם החוג מלא בפרטים אז תפתח אופציית עדכון
            {
                button4.Visible = true;
                button1.Visible = false;
                nameChug.Text = Global.CurrentChug.coursename;
            }
            else
            {
                button4.Visible = false;
             
                button1.Visible = true;
            }
            label11.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את החוג", "מחיקת חוג מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeleteChug(Global.CurrentChug);
                    MessageBox.Show("החוג נמחק בהצלחה");
                    var res = Global.Sharat.UpDateCourse(Global.CurrentChug);
                    Global.CurrentChug = null;
                    this.Hide();
                    ChipusChug w = new ChipusChug();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת החוג");

                }
            }
        }

        private void nameChug_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false || coursim.Select(c => c.coursename).Contains((sender as TextBox).Text))
            {
                label11.Visible = true;
            }
        }
    }
}


