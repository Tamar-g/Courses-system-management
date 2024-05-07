using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRO.ServiceReference1;


namespace PRO
{
    public class Global
    {

        public static Service1Client Sharat = new Service1Client();
        public static  Student CurrentStudent { get; set; }
        public static Teachers CurrentTeacher { get; set; }
        public static Classes Currentkvuza { get; set; }
        public static Product CurrentMuzar { get; set; }
        public static Cities CurrentCity { get; set; }
        public static courses CurrentChug { get; set; }
        public static Cities IR { get; set; }
        public static Cities CurrentIr { get; set; }

        public static int codeChug { get; set; }
        //var d = dataGridView2.AccessibilityObject;
    }

}
