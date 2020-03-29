using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Cw3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    //Controller
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentsDal _dbService;
        private const string ConnString = "Data Source=db-mssql;Initial Catalog=s16712;Integrated Security=True";
        string id = "s11115";

        public StudentController(IStudentsDal dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetStudents([FromServices] IStudentsDal dbService)
        {
            var list = new List<StudentInfoDTO>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                command.CommandText = "select s.FirstName, s.LastName, s.BirthDate, st.Name, e.Semester from Student s join Enrollment e on e.IdEnrollment = s.IdEnrollment join Studies st on st.IdStudy = e.IdStudy";

                sqlConnection.Open();

                SqlDataReader dr = command.ExecuteReader();
                while(dr.Read())
                {
                    var st = new StudentInfoDTO
                    {
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BirthDate = dr["BirthDate"].ToString(),
                        Name = dr["Name"].ToString(),
                        Semester = dr["Semester"].ToString()
                    };

                    list.Add(st);
                }
            }


            return Ok(list);
        }

        //Zadanie 4.3-4.5
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                //command.CommandText = "SELECT * FROM Student WHERE indexnumber=@indexNumber";
                //command.Parameters.AddWithValue("index", indexNumber);
                command.CommandText = "SELECT * FROM Student WHERE indexnumber=@id";
                command.Parameters.AddWithValue("id", id);

                sqlConnection.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    var st = new StudentInfoDTO()
                    {
                        IndexNumber = dr["IndexNumber"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString()
                    };

                    return Ok(st);
                }
            }
                return NotFound("Nie znaleziono studenta.");
        }



    }

}