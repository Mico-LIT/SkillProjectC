using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _007_WebAPI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new int[] { 1, 2, 3, 4, 5 };
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"My Id = {id}";
        }

        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"id {id}  | value {value}";
        }

        [HttpDelete("{id}")]
        public string Deleted(int id)
        {
            return "deleted = " + id;
        }
    }
}
