using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class MockStudentrepository : IStudentrepository
    {
        private readonly StudentDbContext studentDbContext;
        public MockStudentrepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public Student Add(Student student)
        {
            studentDbContext.Students.Add(student);
            studentDbContext.SaveChanges();
            return student;
        }

        public Student Delete(Student student)
        {
           studentDbContext.Students.Remove(student);
            studentDbContext.SaveChanges();
            return student;
        }

        //public Student Delete(int id)
        //{
        //    Student student = studentDbContext.Students.Find(id);
        //    if (student != null)
        //    {
        //        studentDbContext.Remove(student);
        //        studentDbContext.SaveChanges();
        //    }
        //    return student;
        //}

        public IEnumerable<Student> GetAllStudents()
        {
            return studentDbContext.Students;
        }

        public Student GetStudent(int Id)
        {
            return studentDbContext.Students.Find(Id);
        }

   

        public Student Update(Student studentchange)
        {
          var student= studentDbContext.Students.Attach(studentchange);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            studentDbContext.SaveChanges();
            return studentchange;
        }
    }
}
