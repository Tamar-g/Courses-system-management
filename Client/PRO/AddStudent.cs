using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRO.ServiceReference1;

namespace PRO
{
    public partial class AddStudent : Form
    {

        List<string> L = new List<string>();
        List<Cities> B = new List<Cities>();


        public AddStudent()
        {
            InitializeComponent();
            L.Add("זכר");
            L.Add("נקבה");
            comboBox1.DataSource = L;
            B = Global.Sharat.Getallcities().ToList();
            comboBox2.DataSource = B;

        }


        private void textBox3_TextChanged(object sender, EventArgs e)//הכנסת שם פרטי
        {
            label11.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//הכנסת שם משפחה
        {
                label12.Visible = false;
            
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת ת.ז
        {
            label14.Visible=false;
        }

      

        private void textBox5_TextChanged(object sender, EventArgs e)//בחירת תאריך לידה
        {
            label15.Visible=false;
        }

     

   
    

        //הוספת תלמיד
        private void button7_Click(object sender, EventArgs e)//אישור רישום
        {
            if (label11.Visible == true || label12.Visible == true ||
                label13.Visible == true || label14.Visible == true ||
                label15.Visible == true || label16.Visible == true ||
                label17.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה או שחסרים פרטים.");
            }
            else
            {
                Student s = new Student
                {
                    FirstName = textBox3.Text,
                    LastName = textBox4.Text,
                    IdStudent = textBox1.Text,
                    Phone = textBox2.Text,
                    BirthDate = Convert.ToDateTime(dateTimePicker1.Value),
                    Gender = comboBox1.Text,
                    CityCode = Global.Sharat.findCityByTZ(1),
                    Street = textBox9.Text,
                    HouseNum = int.Parse(textBox8.Text)
                };

               // s.IdStudent = Global.Sharat.GetCodeToStudent();
                var w = Global.Sharat.AddStudent(s);
                if (w == 0)
                {
                    MessageBox.Show("שגיאה בהוספת התלמיד");

                }
                else
                {
                    MessageBox.Show("התלמיד נוסף בהצלחה");


                }
            }

        
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            //אם יש תלמיד בגלובל - אז זה עדכון

            if (Global.CurrentStudent != null)
            {
                button3.Visible = true;
                button7.Visible = false;


                textBox1.Text = Global.CurrentStudent.IdStudent;
                textBox1.Enabled = false;
                textBox3.Text = Global.CurrentStudent.FirstName;
                textBox4.Text = Global.CurrentStudent.LastName;
                textBox2.Text = Global.CurrentStudent.Phone;
                textBox9.Text = Global.CurrentStudent.Street;
                comboBox1.Text = Global.CurrentStudent.Gender;
                comboBox2.Text = Global.CurrentStudent.CityCode.NameCity;
                dateTimePicker1.Text = Convert.ToString(Global.CurrentStudent.BirthDate);
                textBox8.Text = Global.CurrentStudent.HouseNum.ToString();
            }
            else
            {
                button3.Visible = false;
                button7.Visible = true;
            }
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var s in L)
                L.Add("זכר");
            L.Add("נקבה");

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
            ChipusStundent w = new ChipusStundent();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

    

        //public void updateStudent()
        //{
        //    //לאסוף מחדש את כל הפרטים 
        //    Global.CurrentStudent.Phone = textBox2.Text;
        //    Global.CurrentStudent.IdStudent = textBox1.Text;
        //    Global.CurrentStudent.FirstName = textBox3.Text;
        //    Global.CurrentStudent.LastName = textBox4.Text;
        //    Global.CurrentTeacher.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
        //    Global.CurrentStudent.CityCode.NameCity = comboBox2.Text;
        //    Global.CurrentStudent.Street = textBox9.Text;
        //    Global.CurrentStudent.HouseNum = int.Parse(textBox8.Text);
        //    var res = Global.Sharat.UpDateStudent(Global.CurrentStudent);
        //    MessageBox.Show("התלמיד עודכן בהצלחה");
        //    Global.CurrentStudent = null;
        //    this.Hide();
        //    ChipusStundent w = new ChipusStundent();
        //    w.FormClosed += (s, ccc) => this.Close();
        //    w.Show();
        //}
        private void button3_Click(object sender, EventArgs e)//עדכון

        {
            if (label11.Visible == true || label12.Visible == true ||
          label13.Visible == true || label14.Visible == true ||
          label15.Visible == true || label16.Visible == true ||
          label17.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה או שחסרים פרטים.");
            }
            else
            {
                //לאסוף מחדש את כל הפרטים 
                Global.CurrentStudent.Phone = textBox2.Text;
                Global.CurrentStudent.IdStudent = textBox1.Text;
                Global.CurrentStudent.FirstName = textBox3.Text;
                Global.CurrentStudent.LastName = textBox4.Text;
                Global.CurrentStudent.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
                Global.CurrentStudent.CityCode.NameCity = comboBox2.Text;
                Global.CurrentStudent.Gender = comboBox1.Text;
                Global.CurrentStudent.Street = textBox9.Text;
                Global.CurrentStudent.HouseNum = int.Parse(textBox8.Text);
                var res = Global.Sharat.UpDateStudent(Global.CurrentStudent);
                MessageBox.Show("התלמיד עודכן בהצלחה");
                Global.CurrentStudent = null;
                this.Hide();
                ChipusStundent w = new ChipusStundent();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את התלמיד", "מחיקת תלמיד מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.Deletedstudent(Global.CurrentStudent);
                    MessageBox.Show("התלמיד נמחק בהצלחה");
                    var res = Global.Sharat.UpDateStudent(Global.CurrentStudent);
                    Global.CurrentStudent = null;
                    this.Hide();
                    ChipusStundent w = new ChipusStundent();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת התלמיד");

                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false)
            {
                label11.Visible = true;
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false)
            {
                label12.Visible = true;
            }
        }


        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (Legal.IsCellPhone((sender as TextBox).Text) == false)
            {
                label13.Visible = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Legal.LegalId((sender as TextBox).Text) == false)
            {
                label14.Visible = true;
            }
        }


        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Today)
            {
                label15.Visible = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label15.Visible = false;
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false)
            {
                label16.Visible = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label16.Visible = false;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (Legal.IsNumber((sender as TextBox).Text) == false)
            {
                label17.Visible = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label17.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label13.Visible = false;
    
        }
    }
}
