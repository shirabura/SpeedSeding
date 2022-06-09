using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTOClass;
namespace API.Controllers
{
    public class DELIVERyController : ApiController
           

    {
        [Route("api/DELIVERy/enterreqwest")]
        [HttpPost]
        public dtoPOSSIBLEDRIVE enterreqwest(long tz, DateTime date, TimeSpan hour, string sourceadress, string destinationadress)
        {
            dtoDELIVERy f = new dtoDELIVERy() { DELIVERID=tz,DATE= date ,HOUR= hour ,SOURSEADRESS= sourceadress ,DESTINATIONADRESS= destinationadress };
            return BLL.MainDelivery.main(f);
            
        }

    }
}
