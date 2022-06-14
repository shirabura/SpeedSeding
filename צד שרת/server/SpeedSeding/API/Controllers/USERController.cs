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

            return    BLL.UserBL.LoginUser(userDetails.id, userDetails.pass);
           
        }
        [Route("api/USER/singup")]
        [HttpPost]
        public Object singup(dtoUSER u)
        {
           
            return BLL.UserBL.SignUp(u);
        }
        [Route("api/USER/GetallUsers")]
        [HttpGet]
        public List<dtoUSER> GetallUsers()
        {

            return BLL.UserBL.GetallUsers();
        }

    }
}
