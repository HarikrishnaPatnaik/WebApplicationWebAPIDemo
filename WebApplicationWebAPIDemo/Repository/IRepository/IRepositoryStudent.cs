using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWebAPIDemo.Model;

namespace WebApplicationWebAPIDemo
{
    public interface IRepositoryStudent
    {
        ICollection<Student> GetAllStudents();
        Student GetStudent(int? id);
        bool IsStudentExists(int? id);
        bool IsStudentExists(string email);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool CreateStudent(Student student);
        bool Save();
    }
}
