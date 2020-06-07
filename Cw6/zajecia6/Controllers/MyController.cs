using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using zajecia6.Models;

namespace zajecia6.Controllers
{
    [ApiController]
    [Route("api/hc")]
    public class MyController : ControllerBase
    {
        private readonly HospitalContext _context;

        public MyController(HospitalContext context)
        {
            _context = context;
        }
        //--------------

        //pobierac dane lekarza - wg id
        [HttpGet ("{id}")]
        public IActionResult getBySurname(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);
            return Ok(doctor);
        }

        //pobierac dane lekarzy
        //api/hc
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        //dodawać nowego lekarza
        //api/hc/{id}
        [HttpPost]
        public IActionResult AddDoctor(string fname, string lname, string email)
        {
            try
            {

                int idLast = _context.Doctors.Count();
            
                Doctor _newDoc = new Doctor();
                //_newDoc.IdDoctor = idLast;
                _newDoc.FirstName = fname;
                _newDoc.LastName = lname;
                _newDoc.Email = email;
            


                //---
                _context.Doctors.Add(_newDoc);
                _context.SaveChanges();


                return Ok("Doctors in db: "+ idLast + "\n New: "+ _newDoc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
}

        //change specific Doctor's data
        //api/hc/3?fname=checkPUT&lname=PUTWorks&email=put@op.pl
        [HttpPut("{id}")]
        public IActionResult setDoctor(int id, string fname, string lname, string email)
        {
            Doctor doctor = _context.Doctors.Find(id);
            doctor.FirstName = fname;
            doctor.LastName = lname;
            doctor.Email = email;

            _context.Doctors.Update(doctor);
            _context.SaveChanges();

            return Ok("Data changed: "+ doctor);
        }

        //remove specified by id Doctor
        [HttpDelete ("{id}")]
        public IActionResult deleteDoctor(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }
    }
}