using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cw7.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class MyController : ControllerBase
    {
        private readonly OrdersContext _context;

        public MyController(OrdersContext context)
        {
            _context = context;
        }
        //--------------


        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.Klienci.ToList());
        }


    }
}
