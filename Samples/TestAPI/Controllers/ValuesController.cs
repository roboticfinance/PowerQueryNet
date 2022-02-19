using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerQueryNet.Client;
using System.IO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string myQueriesPath = Path.Combine(Environment.CurrentDirectory, @"MyQueries");
            var pq = new PowerQueryCommand
            {
                Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
            };

            //var fileURL = "https://synapse4cdm.blob.core.windows.net/excels/4-%E8%B4%A2%E5%8A%A1%E6%8A%A5%E8%A1%A8%E8%A1%A8%E6%A0%B7.xlsx";
            var credentialURL = "https://synapse4cdm.blob.core.windows.net/excels";
            var xlsxFile = string.Format("\"{0}\"", Path.Combine(credentialURL, "4-财务报表表样.xlsx"));
            var xlsxSheet = string.Format("\"{0}\"", "Table1");
            //Add parameter to the query
            pq.Queries.Add("XlsxFilePath", xlsxFile);
            pq.Queries.Add("TableName", xlsxSheet);
            //Add the required credentials
            pq.Credentials.Add(new CredentialKey { Url = credentialURL, Key = "jzwzk378y/lHaSA4hkyqscgYjBTgqD/tW24pw4rMs9kkwMw2QuqCnb+4X7ax244P66vjVzAiRO1I0ScCkDEepg==" });
            var result = pq.Execute("FinBlob");

            return string.Format("Your json is {0}", result.Json);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
