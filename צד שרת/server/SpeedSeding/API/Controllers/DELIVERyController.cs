﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;
using DTOClass;
namespace API.Controllers
{
    public class DELIVERyController : ApiController
           

    {
        [Route("api/DELIVERy/enterreqwest")]
        [HttpPost]
        public USERS enterreqwest(dtoDELIVERy d)
        {
            dtoDELIVERy f = new dtoDELIVERy() { IDOFCUSTUMER=d.IDOFDELIVER,DATE= d.DATE ,HOUR= d.HOUR ,SOURSEADRESS= d.SOURSEADRESS ,DESTINATIONADRESS= d.DESTINATIONADRESS };
            return BLL.MainDelivery.main(f);
            
        }

    }
}
