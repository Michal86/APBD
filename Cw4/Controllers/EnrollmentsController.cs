using System;
using System.Text.Json;
using cw5.DTOs;
using cw5.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace cw5.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly Service.IStudentsDbService _dbService;

        public EnrollmentsController(IStudentsDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetEnrollment(string indexNumber)
        {
            return Ok(_dbService.GetEnrollmentByIndexNumber(indexNumber));
        }
        
        [HttpPost]
        public IActionResult EnrollStudent(EnrollmentRequest request)
        {
            try
            {
                var result = _dbService.EnrollStudent(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}