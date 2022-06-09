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
   
    public class RATINGController : ApiController
    {
       
        [Route("api/RATING/viewrating")]
        [HttpPost]
        public long viewrating(long tz)
        {
            return BLL.RatingBL.CalculatePoint(tz);
        }
       
    }
}
