using Steeltoe.CircuitBreaker.Hystrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway
{
    public class AccountApiCircuitBreaker : HystrixCommand<string>
    {
        public AccountApiCircuitBreaker(IHystrixCommandOptions options)
           : base(options)
        {
           
        }
        protected override string Run()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:7002/api/values").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return data;
        }



        protected override string RunFallback()
        {
            return "Hey I am from fallback";
        }

    }
}
