using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleProjectForSE02.Dtos;
using SimpleProjectForSE02.Models;
using SimpleProjectForSE02.Repositories.Interfaces;

namespace SimpleProjectForSE02.Controllers
{
    // Get api/students => return all Students
    // Post api/students => adds a new student  
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IQueryable<Student>> GetStudents()
        {
            return Ok(_studentRepository.GetStudents());
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDto s)
        {
            Student st = new Student(s);
            if (_studentRepository.AddStudent(st))
            {
                return Ok("Add a new student");
            }
            return BadRequest("Oops, something wrong happened!");
        }




        /* [HttpGet("{param}/{name}")]
         public List<Student> GetStudentsWithName(string param, string value)
         {
             if (param.ToLower().Equals("name"))
             {
                 return students.Where(s => s.Name.ToLower() == value.ToLower()).ToList();
             }
             else if(param.ToLower().Equals("surname"))
             {
                 return students.Where(s => s.Surname.ToLower() == value.ToLower()).ToList();
             }
             return null;


         }*/
    }
}
