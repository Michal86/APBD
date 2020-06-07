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

 
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            if (null == doctor)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        //Pobierac dane lekarzy
        //api/hc
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        //Dodawać nowego lekarza
        //api/hc/
        [HttpPost]
        public IActionResult PostDoctor([Bind("IdDoctor, FirstName, LastName, Email")] Doctor newDoc)
        {
            try
            {
                if (null != _context.Doctors.Find(newDoc))
                {
                    return BadRequest();
                }

                int idLast = _context.Doctors.Count();
                //---

                _context.Doctors.Add(newDoc);
                _context.SaveChanges();

                return Ok("Doctors in db: "+ idLast + "\n New: "+ newDoc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
}

        //change specific Doctor's data
        //api/hc/3?fname=checkPUT&lname=PUTWorks&email=put@op.pl
        [HttpPut]
        public IActionResult EditDoctor([Bind("IdDoctor, FirstName, LastName, Email")] Doctor doctor)
        {
            if (null == _context.Doctors.Find(doctor))
            {
                return BadRequest();
            }

            //---
            _context.Update(doctor);
            _context.SaveChanges();

            return Ok("Data is updated: "+ doctor);
        }

        //remove specified by id Doctor
        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            if (null != doctor)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok("Deleted");
        }
    }
}