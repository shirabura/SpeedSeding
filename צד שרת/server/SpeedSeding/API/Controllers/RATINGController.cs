﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RATINGController : ApiController
    {
        // GET: api/RATING
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RATING/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RATING
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RATING/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RATING/5
        public void Delete(int id)
        {
        }
    }
}
