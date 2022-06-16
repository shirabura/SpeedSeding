using BLL;
using DAL;
using DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBL
    {


        static DBConection db = new DBConection();

        public static List<dtoUSER> GetallUsers()
        {
            List<USERS> list = db.GetDbSet<USERS>().ToList();
            List<dtoUSER> dtoList = dtoUSER.CreateDtoList(list);
            return dtoList;
        }

        public static Object SignUp(dtoUSER user)
        {
            USERS u = user.FromdtoToTable(user);
            db.Execute<USERS>(u, DBConection.ExecuteActions.Insert);
            return u;
        }
   
       

        public static dtoUSER LoginUser(long id, string password)
        { 

            List<dtoUSER> UserInDB = GetallUsers();
            dtoUSER us = UserInDB.FirstOrDefault(s => s.Id== id && s.Password==password);
            return us;   
        }
    }


}

