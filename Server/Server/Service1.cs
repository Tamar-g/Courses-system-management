using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;
namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public Cities GetCitiesByCode(int value)
        {
            return MyDB.Cities.GetCitiesByCode(value);
        }
        public int GetCodeToCities()
        {
            return MyDB.Cities.GetList().Max(x => x.CodeCity) + 1;

        }
  

        public int GetCodeToProduct()
        {
            return MyDB.product.GetList().Max(x => x.productCode) + 1;

        }
    
        //public int GetCodeToRishum()
        //{
        //  //  return MyDB.Rishum.GetList().Max(x => x.RishumCode) + 1;

        //}

        public int GetCodeToClass()
        {
            return MyDB.Classes.GetList().Max(x => x.CodeClass) + 1;

        }
        
        public int GetCodeToCourse()
        {
            return MyDB.Courses.GetAllCourses().Max(x => x.CourseCode) + 1;

        }
        

        public int AddCities(Cities c)
        {
            MyDB.Cities.Add(c);
            return MyDB.Cities.SaveChanges();

        }
        public int AddTeachers(Teachers c)
        {
            MyDB.Teachers.Add(c);
            return MyDB.Teachers.SaveChanges();

        }
        public int AddCourse(courses c)
        {
            MyDB.Courses.Add(c);
            return MyDB.Courses.SaveChanges();

        }
      
        public int AddStudent(Student c)
        {
            MyDB.Student.Add(c);
            return MyDB.Student.SaveChanges();

        }
         public int GetCodeToStudent()
        {
            return 1;
        }

        //public int AddStudentToClass(rishum r)
        //{
        //    //MyDB.rishum.Add(r);
        //    //rishum rishum2 = new rishum();
        //    //MyDB.
        //    //GetClassByCode(r.ClassCode.CodeClass).MoneStudents++;
        //    //return MyDB.Rishum.SaveChanges();
        //}
        public int UpDateCity(Cities s1)
        {
            MyDB.Cities.Update(s1);
            var r = MyDB.Cities.SaveChanges();
            return r;
        }
        public List<Cities> Getallcities()
        {

            return MyDB.Cities.GetList();

        }
        //public int GetCodeToRishum1()
        //{

        //    //return MyDB.Rishum.GetList().Max(p => p.RishumCode) + 1;

        //}

        //חוגים

        public int UpDateCourse(courses c)
        {
            MyDB.Courses.Update(c);
            int i = MyDB.Courses.SaveChanges();
            return i;
        }
        public int Deleted(courses c)
        {

            MyDB.Courses.Deleted(c);
            int i = MyDB.Courses.SaveChanges();
            return i;

        }
        


        public List<Classes> GetClassesBycourse(int n)
        {
            return MyDB.Classes.GetClassesBycourse(n);
        }
        public courses findChugByTZ(int n)
        {
            return MyDB.Courses.GetCourseByCode(n);
        }
        public Cities findCityByTZ(int n)
        {
            return MyDB.Cities.GetCitiesByCode(n);
        }
        public Classes findClassBycode(int n)
        {
            return MyDB.Classes.GetClassByCode(n);
        }
        public Classes findClassByName(string n)
        {
            return MyDB.Classes.GetClassByName(n);
        }
        public Product findProductByTZ(int n)
        {
            return MyDB.product.GetProductByCode(n);
        }
        public Teachers findTeacherByTZ(int n)
        {
            return MyDB.Teachers.GetTeacherById(n.ToString());
        }
        public Student findStudentByTZ(int n)
        {
            return MyDB.Student.GetStudentById(n.ToString());
        }

        public courses GetCourseByCode(int value)
        {
            return MyDB.Courses.GetCourseByCode(value);
        }

        public int DeleteChug(courses n)
        {
            MyDB.Courses.Deleted(n);
            return MyDB.Courses.SaveChanges();
        }
        public Classes GetClassByCode(int n)
        {
            return MyDB.Classes.GetClassByCode(n);
        }
        public Product GetproductByCode(int n)
        {
            return MyDB.product.GetProductByCode(n);
        }

        public List<courses> GetAllCourses()
        {
            return MyDB.Courses.GetAllCourses();
        }

        //מוצרים
        public List<Product> GetallProducts()
        {

            return MyDB.product.GetList();

        }

        public int AddProduct(Product s)
        {
           return MyDB.product.AddProduct(s);
        }
        public int UpdateProduct(Product s)
        {
            MyDB.product.Update(s);
            int i = MyDB.product.SaveChanges();
            return i;
        }
        public int Deletedproduct(Product c)
        {

            MyDB.product.Deleted(c);
            int i = MyDB.product.SaveChanges();
            return i;
        }


        //מורים
        public Teachers GetTeacherById(string value)
        {

            return MyDB.Teachers.GetTeacherById(value);
        }


        public List<Teachers> GetallTeachers()
        {

            return MyDB.Teachers.GetList();

        }
        public int DeletedTeacher(Teachers c)
        {

            MyDB.Teachers.Deleted(c);
            int i = MyDB.Teachers.SaveChanges();
            return i;
        }
        //תלמידים
        public int Deletedstudent(Student c)
        {

            MyDB.Student.Deleted(c);
            int i = MyDB.Student.SaveChanges();
            return i;
        }
        public int UpDateStudent(Student s)
        {
            return MyDB.Student.UpDateStudent(s);
        }
        public List<Student> GetallStudents()
        {

            return MyDB.Student.GetList();

        }


        //קבוצות
        public List<Classes> GetallClasses()
        {

            return MyDB.Classes.GetList();

        }
        public int AddClass(Classes s)
        {
           return MyDB.Classes.AddClass(s);
        }

        public int DeletedClass(Classes c)
        {

            MyDB.Classes.Deleted(c);
            int i = MyDB.Classes.SaveChanges();
            return i;
        }
        public int DeletedCity(Cities c)
        {

            MyDB.Cities.Deleted(c);
            int i = MyDB.Cities.SaveChanges();
            return i;
        }
        
        public int UpDateClass(Classes s)
        {
            return MyDB.Classes.UpDateclass(s);
        }
        public int UpDateTeacher(Teachers s)
        {
            return MyDB.Teachers.UpDateTeacher(s);
        }

    

        public int GetCodeToRishum()
        {
            throw new NotImplementedException();
        }

        public int GetCodeToRishum1()
        {
            throw new NotImplementedException();
        }
    }

}
