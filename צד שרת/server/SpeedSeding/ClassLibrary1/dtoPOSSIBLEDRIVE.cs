using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOClass
{
    public class dtoPOSSIBLEDRIVE
    {
        public long KODOFDRIVE { get; set; }
        public long IDOFDELIVER { get; set; }
        public DateTime DATE { get; set; }
        public TimeSpan HOUR { get; set; }
        public string SOURSEADRESS { get; set; }
        public string DESTINATIONADRESS { get; set; }
        public int CountOfDeliveries { get; set; }

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
            this.CountOfDeliveries = (int)p.CountOfDeliveries;
        }
        public static POSSIBLEDRIVE FromdtoToTable(dtoPOSSIBLEDRIVE p)
        {
            POSSIBLEDRIVE pos = new POSSIBLEDRIVE();
            pos.KODOFDRIVE = p.KODOFDRIVE;
            pos.IDOFDELIVER =p.IDOFDELIVER;
            pos.DATE =p.DATE;
            pos.HOUR =p.HOUR;
            pos.SOURSEADRESS =p.SOURSEADRESS;
            pos.DESTINATIONADRESS =p.DESTINATIONADRESS;
            pos.CountOfDeliveries = p.CountOfDeliveries;
            return pos;

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
