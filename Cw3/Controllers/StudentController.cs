using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return NotFound("Nie znaleziono studenta");
        }

        //Zadanie 5 - przekazywane danych z pomocą QueryString
        [HttpGet]
        public string GetStudents(String orderBy)
        {
            return $"Kowalki, Malewski, Testowy, Andrzejewski sortowanie={orderBy}";
        }
    }



}