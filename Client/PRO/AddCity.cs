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
    public partial class AddCity : Form
    {
        List<Cities> Cities = new List<Cities>();

        public AddCity()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//הכנסת שם עיר
        {
            label11.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)//אישור הוספת העיר
        {
            if (label11.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיימת עיר בשם זה.");
            }
            else
            {

                Cities s = new Cities { NameCity = textBox3.Text, };

                s.CodeCity = Global.Sharat.GetCodeToCities();
                var w = Global.Sharat.AddCities(s);
                if (w == 0)
                {
                    MessageBox.Show(".שגיאה בהוספת העיר, אנא נסה שנית ");

                }
                else
                {
                    MessageBox.Show("העיר נוספה בהצלחה");


                }
            }
        }

        private void AddCity_Load(object sender, EventArgs e)
        {
            Cities = Global.Sharat.Getallcities().ToList();
            label11.Visible = false;
            if (Global.CurrentCity != null)
            {
                button3.Visible = true;
                button4.Visible = false;


                textBox3.Text = Global.CurrentCity.NameCity;

            }
            if (Global.CurrentCity == null)
            {
                button3.Visible = false;
                button4.Visible = true;
            }
            else
            {
                textBox3.Text = Global.CurrentCity.NameCity;
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

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
            ChipusCity w = new ChipusCity();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (label11.Visible == true)
                {
                    MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיימת עיר בשם זה.");

                }
                else
                {
                    //לאסוף מחדש את כל הפרטים 
                    Global.CurrentCity.NameCity = textBox3.Text;
                    var res = Global.Sharat.UpDateCity(Global.CurrentCity);
                    MessageBox.Show("העיר עודכנה בהצלחה");
                    Global.CurrentCity = null;
                    this.Hide();
                    ChipusCity w = new ChipusCity();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את העיר", "מחיקת עיר מן המערכת",
              MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeletedCity(Global.CurrentCity);
                    MessageBox.Show("העיר נמחקה בהצלחה");
                    var res = Global.Sharat.UpDateCity(Global.CurrentCity);
                    Global.CurrentCity = null;
                    this.Hide();
                    ChipusCity w = new ChipusCity();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת העיר");

                }

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false || Cities.Select(c => c.NameCity).Contains((sender as TextBox).Text))
            {
                label11.Visible = true;
            }
        }
    }
    }


