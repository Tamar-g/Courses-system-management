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

    public partial class ChipusTeacher : Form


    {
        List<Teachers> Teachers = new List<Teachers>();

        public ChipusTeacher()
        {
            InitializeComponent();
            button8.Enabled = false;
            button9.Enabled = false;
            Teachers = Global.Sharat.GetallTeachers().ToList();
            dataGridView1.DataSource = Teachers;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//הכנסת ת.ז מורה כדי לחפשו
        {

        }

        private void button3_Click(object sender, EventArgs e)//הוספת מורה חדש
        {
            this.Hide();
            AddTeacher w = new AddTeacher();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
        }

        private void button7_Click(object sender, EventArgs e)//עדכון פרטי מורה
        {

        }

        private void button8_Click(object sender, EventArgs e)//מחיקת מורה
        {
            var tz2 = (dataGridView1.SelectedRows[0].Cells[5].Value).ToString();
            Global.CurrentTeacher = Global.Sharat.findTeacherByTZ(int.Parse(tz2));
            DialogResult answer = MessageBox.Show("?האם אתה בטוח שברצונך למחוק את המורה", "מחיקת מורה מן המערכת",
                 MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    Global.Sharat.DeletedTeacher(Global.CurrentTeacher);
                    MessageBox.Show("המורה נמחק בהצלחה");
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
    

 

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            var TZ = textBox2.Text;
            this.Hide();
            var Z = textBox2.Text;
            var find = Teachers.FirstOrDefault(st => st.IdTeacher == TZ);
            if (find != null)
            {
                Global.CurrentTeacher = find;
                AddTeacher a = new AddTeacher();
                a.FormClosed += (s, ccc) => this.Close();
                a.Show();
            }
            else
            {
                this.Hide();
                ChipusTeacher w = new ChipusTeacher();
                w.FormClosed += (s, ccc) => this.Close();
                w.Show();
                MessageBox.Show("המורה אינו קיים במערכת");

            }
        }

        

        private void ChipusTeacher_Load(object sender, EventArgs e)
        {
            Teachers = Global.Sharat.GetallTeachers().ToList();

            var q = from s in Teachers
                    select new
                    {
                        s.IdTeacher,
                        s.BirthDate,
                        name = s.FirstName + " " + s.LastName,
                        s.CityCode.NameCity,
                        s.Gender,
                        s.Phone,
                        s.Street,
                        s.HouseNum

                    };
            dataGridView1.DataSource = q.ToList();

            dataGridView1.Columns[0].HeaderText = "תז";
            dataGridView1.Columns[1].HeaderText = "קוד קורס";
            dataGridView1.Columns[2].HeaderText = "שם קורס";
            dataGridView1.Columns[3].HeaderText = "עיר";
            dataGridView1.Columns[4].HeaderText = "מגדר";
            dataGridView1.Columns[5].HeaderText = "פלאפון";
            dataGridView1.Columns[6].HeaderText = "רחוב";
            dataGridView1.Columns[7].HeaderText = "מספר בית";

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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var tz2 = (dataGridView1.SelectedRows[0].Cells[0].Value).ToString();
            Global.CurrentTeacher = Global.Sharat.findTeacherByTZ(int.Parse(tz2));
            this.Hide();
            AddTeacher w = new AddTeacher();
            w.FormClosed += (s, ccc) => this.Close();
            w.Show();
           

        }
    }
}
