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
        public string PHONE { get; set; }
        public string Password { get; set; }


        public dtoUSER()
        {

        }

        public dtoUSER(USER u )
        {
            this.Id = u.Id;
            this.FirsteName = u.FirsteName;
            this.LastName = u.LastName;
            this.PHONE = u.PHONE;
            this.Status = u.Status;
            this.Password = u.Password;
        }

        public USER FromdtoToTable()
        {
            throw new NotImplementedException();
        }

        public USER FromdtoToTable(dtoUSER u)
        {
            USER us = new USER();
            us.Id =Id;
            us.FirsteName =FirsteName;
            us.LastName =LastName;
            us.PHONE =PHONE;
            us.Status = Status;
            us.Password = Password;
            return us;
        }
        public static List<dtoUSER> CreateDtoList(List<USER> LIST)
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
