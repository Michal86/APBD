using System;
using cw5.Models;
using cw5.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//na podstawie cw4
namespace cw5.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsDbService _dbService;

        public StudentsController(IStudentsDbService dbService)
        {
            _dbService = dbService;
        }
        
        
        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}"), HttpDelete("{id}"), HttpPut("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (Request.Method == HttpMethods.Get)
            {
                if (id == 1)
                         {
                             return Ok("Kowalski");
                         }
                         else if (id == 2)
                         {
                             return Ok("Malewski");
                         }
            }

            if (Request.Method == HttpMethods.Put)
            {
                return Ok("Aktualizacja dokończona");
            } else if (Request.Method == HttpMethods.Delete)
            {
                return Ok("Usuwanie ukończone");
            }

            return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
    }
}