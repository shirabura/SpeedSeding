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
   
    public class USERController : ApiController
    {
        
        [Route("api/USER/LoginUser")]
        [HttpPost]
        public long LoginUsers(UserDetails userDetails)
        {

            return    BLL.UserBL.LoginUser(userDetails.firstname,userDetails.pass);
           
        }

    }
}
