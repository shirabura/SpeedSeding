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

    public class POSSIBLEDRIVEController : ApiController
    {
      
        [Route("api/POSSIBLEDRIVE/enterpossibledrive")]
        [HttpPost]
        public dtoDELIVERy enterpossibledrive(long tz,DateTime date,TimeSpan hour,string sourceadress,string destinationadress)
        {
            dtoPOSSIBLEDRIVE p = new dtoPOSSIBLEDRIVE() {IDOFDELIVER= tz ,DATE= date ,HOUR= hour ,SOURSEADRESS= sourceadress ,DESTINATIONADRESS= destinationadress };
            return BLL.MainpossibledriveBL.main(p);
             
               
        }

    
    }
}
