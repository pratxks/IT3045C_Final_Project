using Final_Project.Data;
using Final_Project.Interfaces;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class StudentAccessService : IStudentAccessInterface
    {
        private StudentAccessContext _studentAccessContext;

        public StudentAccessService(StudentAccessContext studentAccessContext)
        {
            _studentAccessContext = studentAccessContext;
        }

        public List<Student> GetAllStudents()
        {
            return _studentAccessContext.Student.ToList();
        }

        private Student StudentByID(int id)
        {
            return _studentAccessContext.Student.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public List<Student> GetStudentByID(int id)
        {
            List<Student> studentList = _studentAccessContext.Student.ToList();

            Student studentById = StudentByID(id);

            if (studentById == null)
            {
                return studentList.Take(5).ToList(); 
            }
            else
            {
                return studentList.Where(x => x.Id.Equals(id)).ToList();
            }
        }

        public int? RemoveStudentById(int id)
        {
            var studentToDelete = this.StudentByID(id);

            if (studentToDelete == null) return null;
            try
            {
                _studentAccessContext.Student.Remove(studentToDelete);
                _studentAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateStudent(Student existingStudent)
        {
            var studentToUpdate = this.StudentByID(existingStudent.Id);

            if (studentToUpdate == null)
                return null;

            studentToUpdate.fullName = existingStudent.fullName;
            studentToUpdate.birthDate = existingStudent.birthDate;
            studentToUpdate.programName = existingStudent.programName;
            studentToUpdate.programYear = existingStudent.programYear;

            try
            {
                _studentAccessContext.Student.Update(studentToUpdate);
                _studentAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int? AddStudent(Student newStudent)
        {
            var studentExist = _studentAccessContext.Student.Where(x => x.fullName.Equals(newStudent.fullName) && x.birthDate.Equals(newStudent.birthDate)).FirstOrDefault();

            if (studentExist != null)
            {
                return null;
            }
            try
            {
                _studentAccessContext.Student.Add(newStudent);
                _studentAccessContext.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
