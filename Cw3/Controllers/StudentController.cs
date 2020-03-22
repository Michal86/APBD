using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    //Zadanie 3 - Dodanie kontrolera
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public string GetStudent()
        {
            return "Kowalski, Malewski, Test, Radzewicz, H4x0r, Woźniak";
        }

        //Zadanie 4 - przekazywanie parametru jako URL segment
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta.");
        }


        //Zadanie 5 - przekazywane danych z pomocą QueryString
/*        [HttpGet]
        public string GetStudents(String orderBy)
        {
            return $"Kowalki, Malewski, Testowy, Andrzejewski sortowanie={orderBy}";
        }*/


        //Zadanie 6 - przekazywanie danych w ciele żądania
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";

            return Ok(student);
        }


        //Zadanie 7 - dodanie dodatkowych metod PUT,DELETE
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Aktualizacja dokończona");
            }

            return NotFound("Nie znaleziono studenta, aktualizacja przerwana.");
        }

        [HttpDelete("{id}")]
        public IActionResult DelStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Usuwanie ukończone");
            }

            return NotFound("Nie znaleziono studenta, operacja przerwana.");
        }
    }



}