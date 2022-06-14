using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOClass
{
    public class dtoUSER
    {
        public long Id { get; set; }
        public string FirsteName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


        public dtoUSER()
        {

        }

        public dtoUSER(USERS u )
        {
            this.Id = u.Id;
            this.FirsteName = u.FirsteName;
            this.LastName = u.LastName;
            this.Phone = u.phone;
            this.Status = u.Status;
            this.Password = u.Password;
        }

       

        public USERS FromdtoToTable(dtoUSER u)
        {
            USERS us = new USERS();
            us.Id =Id;
            us.FirsteName =FirsteName;
            us.LastName =LastName;
            us.phone = Phone;
            us.Status = Status;
            us.Password = Password;
            return us;
        }
        public static List<dtoUSER> CreateDtoList(List<USERS> LIST)
        {
            List<dtoUSER> dtolist = new List<dtoUSER>();
            foreach (var p in LIST)
            {
                dtoUSER dtoUSER = new dtoUSER(p);
                dtolist.Add(dtoUSER);

            }
            return dtolist;

        }


    }
}
