using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cw7.Controllers
{
    [ApiController]
    [Route("/api")]
    public class MyController : ControllerBase
    {
        private readonly OrdersContext _context;

        public MyController(OrdersContext context)
        {
            _context = context;
        }
        //--------------


        [HttpGet("{Nazwisko}")]
        public IActionResult ZamowieniaOsoby(string Nazwisko)
        {
            var zamow = _context.Klienci.Include(z => z.Zamowienia).Where(k => k.Nazwisko == Nazwisko).Select(e => e.Zamowienia);


            if (zamow.Count() > 0)
            {
                return Ok(zamow);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("/orders")]
        public IActionResult WszystkiZamowienia()
        {
            var zamow = _context.Zamowienia.Include(z => z.Zam_WyrobCukier).ThenInclude(w => w.WyrobCukierniczy).ToList();


            if (zamow.Count() > 0)
            {
                return Ok(zamow);
            }
            else
            {
                return NotFound();
            }
        }




        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.Klienci.ToList());
        }


    }
}
