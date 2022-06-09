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
        public dtoDELIVERy enterpossibledrive(dtoPOSSIBLEDRIVE z)
        {
            dtoPOSSIBLEDRIVE p = new dtoPOSSIBLEDRIVE() {IDOFDELIVER= z.IDOFDELIVER ,DATE= z.DATE ,HOUR= z.HOUR ,SOURSEADRESS= z.SOURSEADRESS ,DESTINATIONADRESS= z.DESTINATIONADRESS };
            return BLL.MainpossibledriveBL.main(p);
            

        }

    
    }
}
