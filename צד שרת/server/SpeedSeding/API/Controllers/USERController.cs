using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class USERController : ApiController
    {
        // GET: api/USER
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/USER/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/USER
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/USER/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/USER/5
        public void Delete(int id)
        {
        }
    }
}
