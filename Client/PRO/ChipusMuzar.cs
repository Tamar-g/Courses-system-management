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
    public partial class ChipusMuzar : Form
    {

        List<Product> products = new List<Product>();


        public ChipusMuzar()
        {
            InitializeComponent();
            button8.Enabled = false;
            button9.Enabled = false;
        }


        private void Form2_Load(object sender, EventArgs e)
        {

           
            products = Global.Sharat.GetallProducts().ToList();
            var AllCourses = Global.Sharat.GetAllCourses();
            var q = from p in products
                    join r in AllCourses on p.courseCode.CourseCode equals r.CourseCode
                    select new
                    {
                        p.productCode,
                        p.productName,
                        courseName = r.coursename
                    };
            dataGridView2.DataSource = q.ToList();
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת שם מוצר כדי לחפשו
        {

        }

        private void button3_Click(object sender, EventArgs e)//הוספת מוצר חדש
        {
            this.Hide();
            AddMuzar w = new AddMuzar();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();

        }

        private void button9_Click(object sender, EventArgs e)//עידכון מוצר
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentMuzar = Global.Sharat.findProductByTZ(int.Parse(tz2));
            this.Hide();
            AddMuzar w = new AddMuzar();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
            Global.Currentkvuza = null;


        }

        private void button8_Click(object sender, EventArgs e)//מחיקת מוצר
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentMuzar = Global.Sharat.findProductByTZ(int.Parse(tz2));
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את המוצר", "מחיקת ציוד מן המערכת",
                MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.Deletedproduct(Global.CurrentMuzar);
                    MessageBox.Show("המוצר נמחק בהצלחה");
                    Global.CurrentMuzar = null;
                    this.Hide();
                    NetuneyMaharechet1 w = new NetuneyMaharechet1();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת המוצר");

                }

            }
        }
        void DeleteMuzar(int tz2)
        {
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את המוצר", "מחיקת ציוד מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.CurrentMuzar=Global.Sharat.findProductByTZ(tz2);
                   Global.Sharat.Deletedproduct(Global.CurrentMuzar);
                    MessageBox.Show("המוצר נמחק בהצלחה");
                    var res = Global.Sharat.UpdateProduct(Global.CurrentMuzar);
                    Global.CurrentMuzar = null;
                    this.Hide();
                    NetuneyMaharechet1 w = new NetuneyMaharechet1();
                    w.FormClosed += (s, ccc) => this.Close();
                    w.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "שגיאה במחיקת המוצר");

                }

            }
        }
        private void button6_Click(object sender, EventArgs e)//פרטי מוצר
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            NetuneyMaharechet1 w = new NetuneyMaharechet1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

    



        private void button4_Click(object sender, EventArgs e)
        {
            var TZ = textBox1.Text;
            this.Hide();
            var findMuzar = products.FirstOrDefault(st => st.productName.ToString() == TZ);
            if (findMuzar != null)
            {
                Global.CurrentMuzar = findMuzar;
                AddMuzar a = new AddMuzar();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusMuzar w = new ChipusMuzar();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("המוצר אינו קיים במערכת");

            }


        }
        //public Product findMuzarByTZ(int kTZ)
        //{
            
        //}

        public void findMuzarByNAME(string kTZ)
        {
            this.Hide();
            var TZ = textBox1.Text;
            var findMuzar = products.FirstOrDefault(st => st.productName.ToString() == TZ);
            if (findMuzar != null)
            {
                Global.CurrentMuzar = findMuzar;
                AddMuzar a = new AddMuzar();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusMuzar w = new ChipusMuzar();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("המוצר אינו קיים במערכת");

            }

        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            button8.Enabled = true;
            button9.Enabled = true;

        }
    }
}
