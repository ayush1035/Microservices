using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AccountAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ConfigSettings configSettings { get; set; }
        public ValuesController(IOptions<ConfigSettings> settings)
        {
            configSettings = settings.Value;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int userId)
        {
            try
            {
                Log("Info", "Accounts returned for id " + userId + configSettings.AccountToGatewayUrl);
                return new string[] { "Account: abc", "Account : cde", configSettings.AccountToGatewayUrl };
            }
            catch (Exception e)
            {
                return null;
            }

        }

        [HttpGet("chequeBookIssue/{id}")]
        public ActionResult<String> IssueChequeBook(int accId)
        {
            try
            {
                Log("Info", "Cheque Book issued for id " + accId);
                return  "Checque Book Issued" ;
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in issuing Cheque book");
                return null;
            }

        }

        [HttpGet("chequeBookBlock/{id}")]
        public ActionResult<String> BlockChequeBook(int accId)
        {
            try
            {
                Log("Info", "Cheque Book blocked for id " + accId);
                return "Checque Book Blocked";
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in blocking Cheque book");
                return null;
            }

        }

        [HttpGet("{id}/branch/{branchId}")]
        public ActionResult<String> transferAccount(int accId, int branchId)
        {
            try
            {
                Log("Info", "Account transferred to branch " + branchId);
                return "Account transferred to branch " + branchId;
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in transferring branch");
                return null;
            }
        }





        // POST api/values
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            try
            {
                Log("Info", "Account created with id" + 10002 + configSettings.AccountToGatewayUrl);
            }
            catch(Exception e)
            {
                Log("Exception", "Exception in creating account ");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Account account)
        {
            try
            {
                Log("Info", "Account updated with No" + account.AccNo);
            }
            catch (Exception e)
            {
                Log("Exception", "Exception in updating account ");
            }
        }

        // DELETE api/values/5 // account close
        [HttpDelete("{id}")]
        public void Delete(int Accid)
        {
            try
            {
                Log("Info", "Account closed with id" + Accid);
            }
            catch(Exception e)
            {
                Log("Exception", "Exception in deleting account id " + Accid);
            }
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
