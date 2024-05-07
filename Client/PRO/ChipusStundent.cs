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
    public partial class ChipusStundent : Form
    {

        //משתנה בתוך הקלאס אבל מחוץ לפונקציה מוכר בכל הפונקציות

        List<Student> students = new List<Student>();

        public ChipusStundent()
        {
            InitializeComponent();
            button4.Enabled = false;
            button9.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            students = Global.Sharat.GetallStudents().ToList();

            var q = from s in students
                    select new
                    {
                        s.IdStudent,
                        s.BirthDate,
                        name = s.FirstName + " " + s.LastName,
                        s.CityCode.NameCity,
                        s.Gender,
                        s.Phone,
                        s.Street,
                        s.HouseNum

                    };
            dataGridView2.DataSource = q.ToList();

            dataGridView2.Columns[0].HeaderText = "תז";
            dataGridView2.Columns[1].HeaderText = "תאריך לידה";
            dataGridView2.Columns[2].HeaderText = "שם";
            dataGridView2.Columns[3].HeaderText = "עיר";
            dataGridView2.Columns[4].HeaderText = "מגדר";
            dataGridView2.Columns[5].HeaderText = "פלאפון";
            dataGridView2.Columns[6].HeaderText = "רחוב";
            dataGridView2.Columns[7].HeaderText = "מספר בית";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//הכנסת ת.ז תלמיד כדי לחפשו
        {

        }

        private void button12_Click(object sender, EventArgs e)//הוספת תלמיד חדש
        {
            Global.CurrentStudent = null;
            this.Hide();
            AddStudent w = new AddStudent();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();

        }

        private void button4_Click(object sender, EventArgs e)//מחיקת תלמיד
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentStudent = Global.Sharat.findStudentByTZ(int.Parse(tz2));
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את התלמיד", "מחיקת תלמיד מן המערכת",
                MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    int r=Global.Sharat.Deletedstudent(Global.CurrentStudent);
                    Global.CurrentStudent = null;

                    if (r == 0)
                    {
                        MessageBox.Show("נסה שוב");

                    }
                    else
                    {
                    MessageBox.Show("התלמיד נמחק בהצלחה");

                    }
                  
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

        private void button5_Click(object sender, EventArgs e)//הצגת פרטי תלמיד
        {

        }

        public void findStudentByTZ(string TZ)
        {
            this.Hide();
            var findStudent = students.FirstOrDefault(st => st.IdStudent == TZ);
            if (findStudent != null)
            {
                Global.CurrentStudent = findStudent;
                AddStudent a = new AddStudent();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusStundent w = new ChipusStundent();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("התלמיד אינו קיים במערכת");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var TZ = textBox2.Text;
            this.Hide();
            var Z = textBox2.Text;
            var find = students.FirstOrDefault(st => st.IdStudent == TZ);
            if (find != null)
            {
                Global.CurrentStudent = find;
                AddStudent a = new AddStudent();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusStundent w = new ChipusStundent();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("התלמיד אינו קיים במערכת");

            }
        }

    


        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            button4.Enabled = true;
            button9.Enabled = true;
        }

        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            var TZ = textBox2.Text;
            var findStudent = students.FirstOrDefault(st => st.IdStudent == TZ);
            if (findStudent != null)
            {
                Global.CurrentStudent = findStudent;
                AddStudent a = new AddStudent();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
                    {
            //צריך לשלוף מהשורה את הת.ז. ואז אותו קוד בדיוק כמו חפש

            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentStudent = Global.Sharat.findStudentByTZ(int.Parse(tz2));
            this.Hide();
            AddStudent w = new AddStudent();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
            


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
