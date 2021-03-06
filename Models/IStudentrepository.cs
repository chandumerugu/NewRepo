using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
   public interface IStudentrepository
    {
        Student GetStudent(int Id);
        IEnumerable<Student> GetAllStudents();
        Student Add(Student student);
        Student Update(Student studentchange);
        Student Delete(Student student);
     
    }
}
