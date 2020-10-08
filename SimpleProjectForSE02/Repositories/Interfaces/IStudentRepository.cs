using SimpleProjectForSE02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectForSE02.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetStudents();
        bool AddStudent(Student s);
    }
}
