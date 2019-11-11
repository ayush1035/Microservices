using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionsAPI.DTO;

namespace TransactionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int accId)
        {
            try
            {
                Log("Info", "Transaction summary retrieved for ");
                return new string[] { "Transaction Summary 1", "Transaction Summary 2" };
            }
            catch(Exception e)
            {
                Log("Exception", "Exception in retrieving summary of account id " + accId);
                return null;
            }
            
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody] Transaction transaction)
        {
            try
            {
                Log("Info", "Transaction Done");
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in doing Transaction ");
            }
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

        private async Task Log(string type, string value)
        {
            var data = new
            {
                API = "Account",
                Type = type,
                Value = value,
                Time = DateTime.Now
            };

            var http = new HttpClient();
            http.BaseAddress = new Uri("http://loggingapi/api/values");
            await http.PostAsJsonAsync("", data);
        }
    }
}
