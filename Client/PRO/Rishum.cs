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
    public partial class Rishum : Form
    {
        List<Student> students1 = new List<Student>();
        courses d = new courses();
        List<Classes> Classes1 = new List<Classes>();

        public Rishum()
        {
            InitializeComponent();
            d = Global.Sharat.GetCourseByCode(Global.codeChug);
            label3.Text = d.coursename;
            comboBox1.DataSource = students1;
            comboBox3.DataSource = Classes1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var t1 = comboBox1.Text.Substring(comboBox1.Text.IndexOf(':') + 1);
            var t3 = comboBox3.Text.Substring(comboBox3.Text.IndexOf(':') + 1);
            Student s = Global.Sharat.findStudentByTZ(int.Parse(t1));
            Classes kvuza = Global.Sharat.findClassBycode(int.Parse(t3));
            //בדיקות תקינות האם התלמיד מתאים לקבוצה
            kvuza.MoneStudents = kvuza.MoneStudents + 1;
            int age = DateTime.Today.Year - s.BirthDate.Year;
            //if (age >= kvuza.MinAge && age<= kvuza.MaxAge)
            //{
            if (s.Gender == kvuza.Gender && kvuza.MoneStudents < kvuza.MaxNum)
            {

                rishum r = new rishum();
                r.RishumCode = Global.Sharat.GetCodeToRishum1();
                r.CourseCode = d.CourseCode;
                r.ClassCode = kvuza.CodeClass;
             //   int p = Global.Sharat.AddStudentToClass(r);


            }
            // }
            else
            {
                MessageBox.Show("התלמיד/ה אינו מתאים לקבוצה זו");
            }


        }

        private void Rishum_Load(object sender, EventArgs e)
        {
            students1 = Global.Sharat.GetallStudents().ToList();
            var q = from s in students1
                    select new
                    {
                        name = s.FirstName + " " + s.LastName + ":" + s.IdStudent
                    };

            var n = q.ToList().Select(p => p.name).ToList();
            comboBox1.DataSource = n;


            //var q1 = from list in courses1
            //         select new
            //         {
            //             Course = list.coursename + ":" + list.CourseCode 

            //        };

            //var n1 = q1.ToList().Select(p => p.Course).ToList();


            Classes1 = Global.Sharat.GetClassesBycourse(Global.codeChug).ToList();
            var q2 = from list in Classes1
                     select new
                     {
                         class1 = list.NameClass + ":" + list.CodeClass

                     };


            var n3 = q2.ToList().Select(p => p.class1).ToList();

            comboBox3.DataSource = n3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChipusChug w = new ChipusChug();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 w = new Form1();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }
    }
}
