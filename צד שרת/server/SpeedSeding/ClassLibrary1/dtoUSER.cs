using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class dtoUSER
    {
        public long Id { get; set; }
        public string FirsteName { get; set; }
        public string LastName { get; set; }
        public long distance { get; set; }
        public string Status { get; set; }

       public dtoUSER()
        {

        }

        public dtoUSER(USER u )
        {
            this.Id = u.Id;
            this.FirsteName = u.FirsteName;
            this.LastName = u.LastName;
            this.distance = u.distance;
            this.Status = u.Status;
        }
        public USER FromdtoToTable(dtoUSER u)
        {
            USER us = new USER();
            us.Id =Id;
            us.FirsteName =FirsteName;
            us.LastName =LastName;
            us.distance =distance;
            us.Status = Status;
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
