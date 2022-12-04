using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string birthDate { get; set; }
        public string programName { get; set; }
        public string programYear { get; set; }
    }
}
