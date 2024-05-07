using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRO.ServiceReference1;

namespace PRO
{
    public partial class AddTeacher : Form
    {
        List<string> L = new List<string>();
        Teachers w = new Teachers();
        List<Cities> B = new List<Cities>();

        public AddTeacher()
        {

            InitializeComponent();
            L.Add("זכר");
            L.Add("נקבה");
            comboBox1.DataSource = L;
            B = Global.Sharat.Getallcities().ToList();
            comboBox2.DataSource = B;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//הכנס ת.ז
        {
            label14.Visible = false;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//הכנס שם פרטי
        {
            label11.Visible = false;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//הכנס שם משפחה
        {
            label12.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//הכנס מספר פלאפון
        {
            label13.Visible = false;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//בחר תאריך לידה
        {

        }

        private void button3_Click(object sender, EventArgs e)//אישור הוספת מורה
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
                Teachers s = new Teachers
                {
                    FirstName = textBox3.Text,
                    LastName = textBox4.Text,
                    IdTeacher = textBox1.Text,
                    Phone = textBox2.Text,
                    BirthDate = Convert.ToDateTime(dateTimePicker1.Text),
                    Gender = comboBox1.Text,
                    Street = textBox9.Text,
                    HouseNum = int.Parse(textBox8.Text),
               // CityCode = Global.Sharat.GetCitiesByCode(int.Parse(comboBox2.Text)),
               // s.CodeCity = Global.Sharat.GetCodeToCities();
                


            };
              //  var w = Global.Sharat.AddTeacher(s);
                if (true)
                {
                    MessageBox.Show(".שגיאה בהוספת המורה, אנא נסה שנית ");

                }
                else
                {
                    MessageBox.Show("המורה נוסף בהצלחה");


                }

            }

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            if (Global.CurrentTeacher != null)
            {
                button4.Visible = true;
                button3.Visible = false;


                textBox1.Text = Global.CurrentTeacher.IdTeacher;
                textBox1.Enabled = false;
                textBox3.Text = Global.CurrentTeacher.FirstName;
                textBox4.Text = Global.CurrentTeacher.LastName;
                textBox2.Text = Global.CurrentTeacher.Phone;
                comboBox1.Text = Global.CurrentTeacher.Gender;
                comboBox2.Text = Global.CurrentTeacher.CityCode.NameCity;
                textBox8.Text = Global.CurrentTeacher.HouseNum.ToString();
                dateTimePicker1.Text = Convert.ToString(Global.CurrentTeacher.BirthDate);
                textBox9.Text = Global.CurrentTeacher.Street;
            }
            else
            {
                button4.Visible = false;
                button3.Visible = true;
             

            }
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = L;


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
            ChipusTeacher w = new ChipusTeacher();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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
                {

                    //לאסוף מחדש את כל הפרטים 
                    Global.CurrentTeacher.Phone = textBox2.Text;
                    Global.CurrentTeacher.IdTeacher = textBox1.Text;
                    Global.CurrentTeacher.FirstName = textBox3.Text;
                    Global.CurrentTeacher.LastName = textBox4.Text;
                    Global.CurrentTeacher.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
                    Global.CurrentTeacher.Gender = comboBox1.Text;
                    Global.CurrentTeacher.CityCode.NameCity = comboBox2.Text;
                    Global.CurrentTeacher.Street = textBox9.Text;
                    Global.CurrentTeacher.HouseNum = int.Parse(textBox8.Text);

                    var res = Global.Sharat.UpDateTeacher(Global.CurrentTeacher);
                    MessageBox.Show("המורה עודכן בהצלחה");
                    Global.CurrentTeacher = null;
                    this.Hide();
                    ChipusTeacher w = new ChipusTeacher();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את המורה", "מחיקת מורה מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                   Global.Sharat.DeletedTeacher(Global.CurrentTeacher);
                    MessageBox.Show("המורה נמחק בהצלחה");
                    var res =Global.Sharat.UpDateTeacher(Global.CurrentTeacher);
                    Global.CurrentTeacher = null;
                    this.Hide();
                    ChipusTeacher w = new ChipusTeacher();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת המורה");

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

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false)
            {
                label16.Visible = true;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (Legal.IsNumber((sender as TextBox).Text) == false)
            {
                label17.Visible = true;
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label16.Visible = false;

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label17.Visible = false;

        }
    }
}
