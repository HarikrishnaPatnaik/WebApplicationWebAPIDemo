using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWebAPIDemo.Data;
using WebApplicationWebAPIDemo.Model;

namespace WebApplicationWebAPIDemo.Repository
{
    public class RepositoryStudent : IRepositoryStudent
    {
        private ApplicationDBContext _appDbContext;

        public RepositoryStudent(ApplicationDBContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public bool CreateStudent(Student student)
        {            
            _appDbContext.Students.Add(student);            
            return Save();            
        }

        public bool DeleteStudent(Student student)
        {
            _appDbContext.Students.Remove(student);
            return Save();
        }

        public ICollection<Student> GetAllStudents()
        {
            return _appDbContext.Students.ToList();
        }

        public Student GetStudent(int? id)
        {
           Student student =  _appDbContext.Students.SingleOrDefault(std => std.StdId == id);
            return student;
        }

        public bool IsStudentExists(int? id)
        {
           return _appDbContext.Students.Any(std => std.StdId == id);
        }

        public bool IsStudentExists(string email)
        {
            return _appDbContext.Students.Any(std => std.StdEmail.ToLower() == email.ToLower());
        }

        public bool UpdateStudent(Student student)
        {
            _appDbContext.Students.Update(student);
            return Save();
        }

        public bool Save()
        {
            return _appDbContext.SaveChanges() > 0 ? true : false; //ternary operation
        }
    }
}
