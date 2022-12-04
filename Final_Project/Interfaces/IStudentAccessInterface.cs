using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Interfaces
{
    public interface IStudentAccessInterface
    {
        List<Student> GetAllStudents();
        List<Student> GetStudentByID(int id);
        int? RemoveStudentById(int id);
        int? UpdateStudent(Student existingStudent);
        int? AddStudent(Student newStudent);
    }
}
