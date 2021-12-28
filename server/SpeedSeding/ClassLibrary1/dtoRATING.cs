﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class dtoRATING
    {
        public long KODRATING { get; set; }
        public long DELIVERYID { get; set; }
        public string INTEGRITYDELIVER { get; set; }
        public int LATE { get; set; }
        public int SERVISE { get; set; }
        public int GENERAL { get; set; }

        public dtoRATING()
        {

        }
        public dtoRATING(RATING r)
        {
            this.KODRATING = r.KODRATING;
            this.DELIVERYID = (long)r.DELIVERYID;
            this.INTEGRITYDELIVER = r.INTEGRITYDELIVER;
            this.LATE = (int)r.LATE;
            this.SERVISE = (int)r.SERVISE;
            this.GENERAL =(int)r.GENERAL;



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