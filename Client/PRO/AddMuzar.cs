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
    public partial class AddMuzar : Form
    {
        List<courses> B = new List<courses>();
        List<Product> products = new List<Product>();


        public AddMuzar()
        {
            InitializeComponent();
            B = Global.Sharat.GetAllCourses().ToList();
            comboBox5.DataSource = B;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//הכנסת שם מוצר
        {
            label11.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)//אישור הוספת המוצר
        {
            if (label11.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיים מוצר בשם זה.");
            }
            else
            {
                Product s = new Product { productName = textBox3.Text };

                s.productCode = Global.Sharat.GetCodeToProduct();
                var w = Global.Sharat.AddProduct(s);
                if (w == 0)
                {
                    MessageBox.Show("שגיאה בהוספת המוצר");

                }
                else
                {
                    MessageBox.Show("המוצר נוסף בהצלחה");


                }
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

        private void AddMuzar_Load(object sender, EventArgs e)
        {
            products = Global.Sharat.GetallProducts().ToList();
            if (Global.CurrentMuzar != null)
            {
                button3.Visible = true;
                button4.Visible = false;


                textBox3.Text = Global.CurrentMuzar.productName;
                comboBox5.Text = Global.CurrentMuzar.courseCode.ToString();
               //string f= (MyDB.Courses.GetCourseByCode(int.Parse(Global.CurrentMuzar.courseCode))).ToString();
                //comboBox5.Text = f;

            }
            else
            {
                button3.Visible = false;
                button4.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label11.Visible == true)
            {
                MessageBox.Show("מלאת מספר פרטים בצורה בלתי תקינה, חסרים פרטים או שכבר קיים מוצר בשם זה.");
            }
            else
            {
                {

                    //לאסוף מחדש את כל הפרטים 
                    Global.CurrentMuzar.productName = textBox3.Text;
                    Global.CurrentMuzar.courseCode.coursename = comboBox5.Text;
                    var res = Global.Sharat.UpdateProduct(Global.CurrentMuzar);
                    MessageBox.Show("המוצר עודכן בהצלחה");
                    Global.CurrentMuzar = null;
                    this.Hide();
                    ChipusMuzar w = new ChipusMuzar();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
    
            DialogResult answer = MessageBox.Show( "?האם אתה בטוח שברצונך למחוק את המוצר","מחיקת ציוד מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                   Global.Sharat.Deletedproduct(Global.CurrentMuzar);
                    MessageBox.Show("המוצר נמחק בהצלחה");
                    var res = Global.Sharat.UpdateProduct(Global.CurrentMuzar);
                    Global.CurrentMuzar = null;
                    this.Hide();
                    NetuneyMaharechet1 w = new NetuneyMaharechet1();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message+"שגיאה במחיקת המוצר");

                }

            }


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Legal.IsHebrew((sender as TextBox).Text) == false || products.Select(c => c.productName).Contains((sender as TextBox).Text))
            {
                label11.Visible = true;
            }
        }
    }
}
