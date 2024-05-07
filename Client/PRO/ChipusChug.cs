using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PRO.ServiceReference1;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PRO
{
    public partial class ChipusChug : Form
    {
        List<courses> courses = new List<courses>();
        int code;
        public ChipusChug()
        {
            InitializeComponent();
            button5.Enabled = false;
            button7.Enabled = false; button8.Enabled = false;
            button6.Enabled = false;

        }
        public courses findChugByTZ(int DTZ)
        {

            this.Hide();
            var TZ =int.Parse( textBox1.Text);
            var find = courses.FirstOrDefault(st => st.CourseCode == TZ);
            if (find != null)
            {
                Global.CurrentChug = find;
                AddChug a = new AddChug();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusChug w = new ChipusChug();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("החוג אינו קיים במערכת");

            }
            return Global.CurrentChug;
        }
        public courses findChugByNAME(string DTZ)
        {

            this.Hide();
            var TZ = textBox1.Text;
            var find = courses.FirstOrDefault(st => st.coursename.ToString() == TZ);
            if (find != null)
            {
                Global.CurrentChug = find;
                AddChug a = new AddChug();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusChug w = new ChipusChug();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("החוג אינו קיים במערכת");

            }
            return Global.CurrentChug;
        }

        private void ChipusChug_Load(object sender, EventArgs e)
        {
            courses =Global.Sharat.GetAllCourses().ToList();
            //foreach (var item in courses)
            //{
            //    Button b = new Button();
            //    b.Text = item.coursename;
            //    b.Tag = item;
            //    b.Width = 200;
            //    b.Height = 100;
            //}
            
            dataGridView2.DataSource = courses;

        }
        private void buttonB(object sender, EventArgs e)
        {
            //להגיע לרשימת הקבוצות של קורס זה
            //שליחת הקוד של הקורס ולקבל את כל הקבוצות
            var course = ((sender as Button).Tag) as courses;
            var listGroupes = Global.Sharat.GetClassesBycourse(course.CourseCode);
            dataGridView2.DataSource = listGroupes;


        }
        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת חוג לחיפוש
        {

        }

        private void button3_Click(object sender, EventArgs e)//הוספת חוג חדש
        {
            this.Hide();
            AddChug w = new AddChug();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button8_Click(object sender, EventArgs e)//רישום לחוג
        {
            this.Hide();
            Rishum w = new Rishum();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button6_Click(object sender, EventArgs e)//פתיחת קבוצה
        {
            code = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            this.Hide();
            AddKvuza k = new AddKvuza();
            // k.set(course);
            k.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {  
           
         
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentChug=Global.Sharat.findChugByTZ(int.Parse(tz2)); 
            this.Hide();
            AddChug w = new AddChug();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
            Global.CurrentChug = null;

         

            //var res = Global.Sharat.UpDateCourse(Global.CurrentChug);
            //MessageBox.Show("החוג עודכן בהצלחה");
            //Global.CurrentChug = null;


        }

        private void button5_Click(object sender, EventArgs e)//מחיקת הקורס מהמערכת
        {
            var tz2 = (dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentChug = Global.Sharat.findChugByTZ(int.Parse(tz2));
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את החוג", "מחיקת חוג מן המערכת",
                MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeleteChug(Global.CurrentChug);
                    MessageBox.Show("החוג נמחק בהצלחה");
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
            //string tz2 = (dataGridView1.SelectedRows[0].Cells[0].Value).ToString();
            //DeleteChug(int.Parse(tz2));
            //int tz2 = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //  DeleteChug(tz2);




        }
        void DeleteChug(int tz2)
        {
            //var code1 = int.Parse(tz2);
           Global.CurrentChug=findChugByTZ(tz2);
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

        private void button4_Click(object sender, EventArgs e)//פרטים אודות קבוצה
        {
            var k = Global.Sharat.GetClassByCode(code);
            string s = "";

        }

        private void button9_Click(object sender, EventArgs e)//בהקלדת שם חוג הוא ימצרא את החוג
        {
            var TZ = textBox1.Text;
            //Global.Sharat.findChugByTZ(int.Parse(TZ));
            this.Hide();
            var find = courses.FirstOrDefault(st => st.coursename.ToString() == TZ);
            if (find != null)
            {
                Global.CurrentChug = find;
                AddChug a = new AddChug();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusChug w = new ChipusChug();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("החוג אינו קיים במערכת");

            }
            //this.Hide();
            //var Name = textBox1.Text;
            ////var find = foreach(st => st.coursename == Name);
            //var find = courses.FirstOrDefault(st => st.coursename == Name);
            ////st => st.IdStudent == TZ
            //if (find != null)
            //{
            //    Global.CurrentChug = find;
            //    AddChug a = new AddChug();
            //    a.FormClosed += (s, ccc) => this.Close();
            //    a.Show();
            //}
            //else
            //{
            //    MessageBox.Show("החוג אינו נמצא במערכת");

            //    //    }
            //    //    //var TZ = textBox1.Text;
            //    //    //var findCours = courses.FirstOrDefault(st => st.CourseCode.ToString() == TZ);
            //    //    //if (findCours != null)
            //    //    //{
            //    //    //    Global.CurrentChug = findCours;
            //    //    //    AddChug a = new AddChug();
            //    //    //    a.FormClosed += (s, ccc) => this.Close();
            //    //    //    a.Show();
            //    //    //}
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //להגיע לרשימת הקבוצות של קורס זה
            //שליחת הקוד של הקורס ולקבל את כל הקבוצות
            var cell = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            var listGroupes = Global.Sharat.GetClassesBycourse(cell);
            dataGridView1.DataSource = listGroupes;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            code = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Global.codeChug = code;
            button8.Enabled = true;

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            //להגיע לרשימת הקבוצות של קורס זה
            //שליחת הקוד של הקורס ולקבל את כל הקבוצות
            var cell = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            var listGroupes = Global.Sharat.GetClassesBycourse(cell);
            var q = from list in listGroupes
                    select new
                    {
                        CourseCode = list.CourseCode.CourseCode,
                        CourseName = list.CourseCode.coursename,
                       
                        list.Gender,
                        list.Level,
                        list.MoneStudents,
                        list.Status,
                        list.DurationInMinutes,
                        //city = list.CodeCity.NameCity,
                        list.MaxNum,
                        teacherId = list.TeacherId.IdTeacher,
                        teacherName = list.TeacherId.FirstName + " " + list.TeacherId.LastName, 
                        NameClass = list.NameClass,
                    };
            dataGridView1.DataSource = q.ToList();
            dataGridView1.Columns[0].HeaderText = "קוד קורס";
            dataGridView1.Columns[1].HeaderText = "שם קורס";
            dataGridView1.Columns[2].HeaderText = "מגדר";
            dataGridView1.Columns[3].HeaderText = "רמה";
            dataGridView1.Columns[4].HeaderText = "כמות תלמידות";
            dataGridView1.Columns[5].HeaderText = "סטטוס";
            dataGridView1.Columns[6].HeaderText = "זמן שיעור";
            //dataGridView1.Columns[7].HeaderText = "עיר";
            dataGridView1.Columns[7].HeaderText = "מקסימלית";
            dataGridView1.Columns[8].HeaderText = "קוד מורה";
            dataGridView1.Columns[9].HeaderText = "שם מורה";
            dataGridView1.Columns[10].HeaderText = "שם קבוצה";


            button6.Enabled = true; button5.Enabled = true;
            button7.Enabled = true;

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
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

      

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChipusKvuza w = new ChipusKvuza();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        
    }
}
