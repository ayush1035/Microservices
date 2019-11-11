using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LoggingAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {   
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Log>> Get()
        {
            return Logger.logs;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Log value)
        {
            Logger.logs.Add(value);
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
