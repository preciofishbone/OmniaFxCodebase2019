using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omnia.Codebase2019.Models;

namespace Omnia.Codebase2019.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBeerController : ControllerBase
    {
        // GET: api/Beer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderBeer/5
        [HttpGet("{userId}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderBeer
        [HttpPost]
        public void Post([FromBody] BasicBeer beer)
        {
        }
    }
}
