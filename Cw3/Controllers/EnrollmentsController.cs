using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private const string ConnString = "Data Source=db-mssql;Initial Catalog=s16712;Integrated Security=True";

        [HttpPost]
        public void EnrollStudent()
        {
            using (var connection = new SqlConnection(ConnString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();

                var tran = connection.BeginTransaction();

                try
                {

                }
                catch(SqlException ex)
                {
                    tran.Rollback();
                  
                }

                var response = new Enrollment();
                return CreatedAtAction(response);
            }
        }

        private void CreatedAtAction(Enrollment response)
        {
            throw new NotImplementedException();
        }
    }
}