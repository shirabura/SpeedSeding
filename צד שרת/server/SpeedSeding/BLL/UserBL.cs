﻿using BLL;
using DAL;
using DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    // public class UserBL
    //{
      
        

    //        static DBConection db = new DBConection();

    //        public static List<dtoUSER> GetallUsers()
    //        {
    //            List<USERS> list = db.GetDbSet<USERS>().ToList();
    //            List<dtoUSER> dtoList = dtoUSER.CreateDtoList(list);
    //            return dtoList;
    //        }

    //        public static Object SignUp(dtoUSER user)
    //        {
    //        USERS u = user.FromdtoToTable();
    //            db.Execute<USERS>(u, DBConection.ExecuteActions.Insert);
    //            return u;
    //        }
    //        public static Object SignIn(UserDetails ud)
    //        {

    //        USERS u = db.GetDbSet<USERS>().FirstOrDefault(u1 => u1.FirsteName == ud.firstname);
    //            if (u == null)
    //                return new { success = false, massage = "user does not exist" };
    //            else if (!u.Password.Equals(ud.Password))
    //                return new { success = false, massage = "Password is wrong" };
    //            else
    //                return new { success = true, user = new dtoUSER(u), massage = "Login success" };
    //        }

        
    //}


}

