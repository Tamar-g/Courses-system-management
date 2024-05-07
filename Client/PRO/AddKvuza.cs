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
    

    public partial class AddKvuza : Form

    {
        List<string> L = new List<string>();
        List<string> Mazav = new List<string>();
        List<string> Shalav = new List<string>();
        List<string> time = new List<string>();
        List<courses> B = new List<courses>();
        List<Teachers> morim= new List<Teachers>();
        List<Cities> h = new List<Cities>();
        List<Classes> Classes = new List<Classes>();
        public AddKvuza()
        {
            InitializeComponent();
            L.Add("זכר");
            L.Add("נקבה");
            comboBox3.DataSource = L;
            Mazav.Add("פעיל");
            Mazav.Add("לא פעיל");
            comboBox1.DataSource = Mazav;
            Shalav.Add("מתחילים");
            Shalav.Add("מתקדמים");
            comboBox2.DataSource = Shalav;
            time.Add("ארבעים וחמש דקות");
            time.Add("שישים דקות");
            comboBox4.DataSource = time;
            B = Global.Sharat.GetAllCourses().ToList();
            h= Global.Sharat.Getallcities().ToList();
            morim= Global.Sharat.GetallTeachers().ToList();
            comboBox7.DataSource = morim ;
            comboBox6.DataSource = h;
            comboBox5.DataSource = B;


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void AddKvuza_Load(object sender, EventArgs e)
        {
            Classes = Global.Sharat.GetallClasses().ToList();
            if (Global.Currentkvuza != null)
            {
                button1.Visible = false;
                leidkun.Visible = true;


                name.Text = Global.Currentkvuza.NameClass.ToString();
                textBox1.Text = Global.Currentkvuza.MaxNum.ToString();
                textBox2.Text = Global.Currentkvuza.MinAge.ToString();
                textBox3.Text = Global.Currentkvuza.MaxAge.ToString();
                comboBox3.Text = Global.Currentkvuza.Gender.ToString();
                comboBox1.Text = Global.Currentkvuza.Status.ToString();
                comboBox2.Text = Global.Currentkvuza.Level.ToString();
                comboBox4.Text = Global.Currentkvuza.DurationInMinutes.ToString();
                comboBox5.Text = Global.Currentkvuza.CourseCode.ToString();
                comboBox6.Text = Global.Currentkvuza.CodeCity.ToString();
                comboBox7.Text = Global.Currentkvuza.TeacherId.ToString();
            }
            else
            {

                button1.Visible = true;
                leidkun.Visible = false;
               
            }
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label17.Visible == true|| label18.Visible == true || label19.Visible == true || label20.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיימת קבוצה בשם זה.");
            }
            else
            {
                Classes s = new Classes
                {
                    NameClass = name.Text,
                    MaxNum = int.Parse(textBox1.Text),
                    MinAge = int.Parse(textBox2.Text),
                    MaxAge = int.Parse(textBox3.Text),
                    Gender = comboBox3.Text,
                    Status = comboBox1.Text,
                    Level = comboBox2.Text,
                    CourseCode = Global.Sharat.GetCourseByCode(int.Parse(comboBox2.Text)),
                    CodeCity = Global.Sharat.GetCitiesByCode(int.Parse(comboBox2.Text)),
                    DurationInMinutes = int.Parse(comboBox4.Text),
                    TeacherId = Global.Sharat.GetTeacherById(comboBox7.Text)
                };

                s.CodeClass = Global.Sharat.GetCodeToClass();
                var w = Global.Sharat.AddClass(s);
                if (w == 0)
                {
                    MessageBox.Show("שגיאה בהוספת הקבוצה");

                }
                else
                {
                    MessageBox.Show("הקבוצה נוספה בהצלחה");


                }
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label20.Visible = false;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void leidkun_Click_1(object sender, EventArgs e)
        {
            if (label17.Visible == true || label18.Visible == true || label19.Visible == true || label20.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיימת קבוצה בשם זה.");
            }
            else
            {
                //לאסוף מחדש את כל הפרטים 
                Global.Currentkvuza.NameClass = name.Text;
                Global.Currentkvuza.Gender = comboBox3.Text;
                Global.Currentkvuza.Status = comboBox1.Text;
                Global.Currentkvuza.Level = comboBox2.Text;
                Global.Currentkvuza.DurationInMinutes = int.Parse(comboBox4.Text);
                Global.Currentkvuza.MaxNum = int.Parse(textBox1.Text);
                Global.Currentkvuza.MaxAge = int.Parse(textBox3.Text);
                Global.Currentkvuza.MinAge = int.Parse(textBox2.Text);
                Global.Currentkvuza.TeacherId = Global.Sharat.GetTeacherById(comboBox7.Text);
                Global.Currentkvuza.CourseCode = Global.Sharat.GetCourseByCode(int.Parse(comboBox5.Text));
                Global.Currentkvuza.CodeCity = Global.Sharat.GetCitiesByCode(int.Parse(comboBox5.Text));
                var res = Global.Sharat.UpDateClass(Global.Currentkvuza);
                MessageBox.Show("הקבוצה עודכנה בהצלחה");
                Global.Currentkvuza = null;
                this.Hide();
                ChipusKvuza w = new ChipusKvuza();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את הקבוצה", "מחיקת קבוצה מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeletedClass(Global.Currentkvuza);
                    MessageBox.Show("הקבוצה נמחקה בהצלחה");
                    var res = Global.Sharat.UpDateClass(Global.Currentkvuza);
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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false || Classes.Select(c => c.NameClass).Contains((sender as TextBox).Text))
            {
                label17.Visible = true;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Legal.IsNumber((sender as TextBox).Text) == false)
            {
                label18.Visible = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Legal.IsNumber((sender as TextBox).Text) == false)
            {
                label19.Visible = true;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Legal.IsNumber((sender as TextBox).Text) == false)
            {
                label20.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label18.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label19.Visible = false;

        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            label17.Visible = false;

        }
    }
}
