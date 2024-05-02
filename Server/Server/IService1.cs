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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {



        [OperationContract]

        Cities GetCitiesByCode(int value);

        [OperationContract]
        int GetCodeToCities();

        [OperationContract]
        List<Cities> Getallcities();
        [OperationContract]
        int AddCities(Cities c);

        //[OperationContract]
        //int AddStudentToClass(rishum r);
        [OperationContract]
        int GetCodeToStudent();
        [OperationContract]
        int UpDateCity(Cities s1);
        [OperationContract]

        int UpdateProduct(Product s);

        [OperationContract]

        int GetCodeToProduct();

        [OperationContract]
        int DeletedCity(Cities c);
        [OperationContract]
        int GetCodeToCourse();
        [OperationContract]
        int AddCourse(courses c);
        [OperationContract]

        int AddStudent(Student c);
     
        //חוגים
        [OperationContract]
        int GetCodeToRishum();

        [OperationContract]
        int AddTeachers(Teachers c);
        [OperationContract]

        int GetCodeToRishum1();
        [OperationContract]
        int UpDateCourse(courses c);

        [OperationContract]
        List<courses> GetAllCourses();
        [OperationContract]
        List<Classes> GetClassesBycourse(int n);
        [OperationContract]
        courses findChugByTZ(int n);
        [OperationContract]
        Cities findCityByTZ(int n);
        [OperationContract]
        Classes findClassByName(string n);
     

        [OperationContract]
        Classes findClassBycode(int n);
        [OperationContract]
        Product findProductByTZ(int n);
        [OperationContract]
        Teachers findTeacherByTZ(int n);
        [OperationContract]
        Student findStudentByTZ(int n);
        [OperationContract]
        int DeleteChug(courses n);
        [OperationContract]
        Classes GetClassByCode(int n);
        [OperationContract]
        courses GetCourseByCode(int value);
        //מוצרים
        [OperationContract]
        List<Product> GetallProducts();
        [OperationContract]
        int AddProduct(Product s);
        [OperationContract]

        int Deletedproduct(Product s);


        //מורים
        [OperationContract]
        List<Teachers> GetallTeachers();
        [OperationContract]
        int DeletedTeacher(Teachers c);
        //תלמידים
        [OperationContract]
        List<Student> GetallStudents();
        [OperationContract]
        int Deletedstudent(Student s);
        [OperationContract]
        int UpDateStudent(Student s);
        [OperationContract]
        Teachers GetTeacherById(string id);
        //קבוצות
        [OperationContract]
        List<Classes> GetallClasses();
        [OperationContract]
        int UpDateClass(Classes s);
        [OperationContract]
        int DeletedClass(Classes c);
        [OperationContract]
        int UpDateTeacher(Teachers s);
        [OperationContract]
        int GetCodeToClass();
        [OperationContract]
        int AddClass(Classes s);
    }


}

