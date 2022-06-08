using BLL;
using DTOClass;
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

    public class POSSIBLEDRIVEController : ApiController
    {
        // GET: api/POSSIBLEDRIVE
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/POSSIBLEDRIVE/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/POSSIBLEDRIVE
       
        //public void Post([FromBody]string value)
        //{
        //}
        [Route("api/POSSIBLEDRIVE/enterpossibledrive/{tz}/{date}/{hour}/{sourceadress}/{destinationadress}")]
        [HttpGet]
        public long enterpossibledrive(long tz,DateTime date,TimeSpan hour,string sourceadress,string destinationadress)
        {
            return  BLL.MainpossibledriveBL.main(tz, date, hour, sourceadress, destinationadress);
        }

        // PUT: api/POSSIBLEDRIVE/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/POSSIBLEDRIVE/5
        public void Delete(int id)
        {
        }
    }
}
