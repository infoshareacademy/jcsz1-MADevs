using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;
using WebCultureInGdansk.Dtos;

//using ReportModule.Models;

namespace ReportModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        // GET api/reports
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // Wez wszystkie raporty z bazy i zwroc 
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReportDto report)
        {
            //Tutaj bedzie parsowanie i dodawanie reportu do bazy.
            
            

            // Repository.Add(reportDbModel)
            return StatusCode(201);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
