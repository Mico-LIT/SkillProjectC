using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.Api
{
    public class ValuesController : ApiController
    {
        public string GetValue()
        {
            return "getValue";
        }

        public string Get(int id)
        {
            return "Id :" + id.ToString();
        }
    }
}
