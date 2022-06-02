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
    public class USERController : ApiController
    {
        // GET: api/USER
        //public List<dtoUSER> GetallUsers()
        //{

        //    List<dtoUSER> list = BLL.UserBL.GetallUsers();
        //    return list;
        //}

        // POST: api/USER
        [Route("api/USER/LoginUser/{userName}/{password}")]
        [HttpGet]
        public long LoginUsers(string userName,string password)
        {

            return    BLL.UserBL.LoginUser(userName,password);
           
        }

        // PUT: api/USER/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/USER/5
        public void Delete(int id)
        {
        }
    }
}
