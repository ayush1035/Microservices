using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAPI.DTO;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "User1", "User2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "User 1";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            try
            {
                Log("Info", "User created with id" + 10002);
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in creating user ");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            try
            {
                Log("Info", "User updated with Id " + user.UserId);
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in updating user ");
            }
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
