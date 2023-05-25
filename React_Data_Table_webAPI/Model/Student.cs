using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace React_Data_Table_webAPI.Model
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentAddress { get; set; }
    }
}
