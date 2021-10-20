using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordViewer.DL
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year1Credits { get; set; }
        public int Year2Credits { get; set; }
        public int Year3Credits { get; set; }
        public int Year4Credits { get; set; }
        public int Year5Credits { get; set; }
        public DegreeStatus StudentStatus { get; set; }
    }
}
