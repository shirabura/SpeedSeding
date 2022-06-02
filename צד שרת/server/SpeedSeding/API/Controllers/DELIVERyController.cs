using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DELIVERyController : ApiController
           

    {
        // GET: api/DELIVERy
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DELIVERy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DELIVERy
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DELIVERy/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DELIVERy/5
        public void Delete(int id)
        {
        }
    }
}
