﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class dtoPOSSIBLEDRIVE
    {
        public long KODOFDRIVE { get; set; }
        public long IDOFDELIVER { get; set; }
        public DateTime DATE { get; set; }
        public TimeSpan HOUR { get; set; }
        public string SOURSEADRESS { get; set; }
        public string DESTINATIONADRESS { get; set; }

        public dtoPOSSIBLEDRIVE()
        {
        }
        public dtoPOSSIBLEDRIVE(POSSIBLEDRIVE p)
        {
            this.KODOFDRIVE = p.KODOFDRIVE;
            this.IDOFDELIVER = (long)p.IDOFDELIVER;
            this.DATE = (DateTime)p.DATE;
            this.HOUR = (TimeSpan)p.HOUR;
            this.SOURSEADRESS = p.SOURSEADRESS;
            this.DESTINATIONADRESS = p.DESTINATIONADRESS;

        }
        public static List<dtoPOSSIBLEDRIVE> CreateDtoList(List<POSSIBLEDRIVE> LIST)
        {
            List<dtoPOSSIBLEDRIVE> dtolist = new List<dtoPOSSIBLEDRIVE>();
            foreach(var p in LIST)
            {
                dtoPOSSIBLEDRIVE dtoPOSSIBLEDRIVE = new dtoPOSSIBLEDRIVE(p);
                dtolist.Add(dtoPOSSIBLEDRIVE);
                
            }
            return dtolist;
        }



    }

}
