using Microsoft.EntityFrameworkCore;
using SimpleProjectForSE02.Data;
using SimpleProjectForSE02.Models;
using SimpleProjectForSE02.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectForSE02.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddStudent(Student s)
        {
            _context.Students.Add(s);
            return _context.SaveChanges() > 0;
        }

        public IQueryable<Student> GetStudents()
        {
            return _context.Students.Include(x => x.Group).OrderBy(x => x.Name);
        }
    }
}
