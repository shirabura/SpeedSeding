﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOClass
{
    public class dtoRATING
    {
        public long DELIVERYID { get; set; }
        public long IDOFDELIVER { get; set; }
        public int INTEGRITYDELIVER { get; set; }
        public int LATE { get; set; }
        public int SERVISE { get; set; }
        public int GENERAL { get; set; }
        public long SamPoint { get; set; }
        public dtoRATING()
        {

        }
        public dtoRATING(RATING r)
        {
         
            this.DELIVERYID = r.DELIVERYID;
            this.IDOFDELIVER = (long)r.IDOFDELIVER;
            this.INTEGRITYDELIVER = (int)r.INTEGRITYDELIVER;
            this.LATE = (int)r.LATE;
            this.SERVISE = (int)r.SERVISE;
            this.GENERAL =(int)r.GENERAL;
            this.SamPoint = (long)r.SamPoint;



        }
        public static RATING FROMdtoToTable(dtoRATING u)
        {
            RATING ra = new RATING();
            ra.IDOFDELIVER = u.IDOFDELIVER;
            ra.DELIVERYID = u.DELIVERYID;
            ra.INTEGRITYDELIVER =u.INTEGRITYDELIVER;
            ra.LATE = u.LATE;
            ra.SERVISE =u.SERVISE;
            ra.GENERAL = u.GENERAL;
            ra.SamPoint = (long)u.SamPoint;
            return ra;
        }
        public static List<dtoRATING> CreateDtoList(List<RATING> LIST)
        {
            List<dtoRATING> dtolist = new List<dtoRATING>();
            foreach (var p in LIST)               
            {
                dtoRATING dtoRATING = new dtoRATING(p);
                dtolist.Add(dtoRATING);

            }
            return dtolist;
        }

    }

}
