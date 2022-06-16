using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOClass
{
    public class dtoDELIVERy
    {
        public long DELIVERID { get; set; }
        public long IDOFDELIVER { get; set; }
        public long IDOFCUSTUMER { get; set; }
        public DateTime DATE { get; set; }
        public Boolean RESPOND { get; set; }
        public string SOURSEADRESS { get; set; }
        public string DESTINATIONADRESS { get; set; }
        public Boolean DONE { get; set; }
        public Nullable<System.TimeSpan> HOUR { get; set; }

        public dtoDELIVERy()
        {
        }
        public dtoDELIVERy(DELIVERIES d)
        {
            this.DELIVERID = d.DELIVERID;
            this.IDOFDELIVER = (long)d.IDOFDELIVER;
            this.IDOFCUSTUMER = (long)d.IDOFCUSTUMER;
            this.DATE = (DateTime)d.DATE;
            this.RESPOND = (bool)d.RESPOND;
            this.SOURSEADRESS = d.SOURSEADRESS;
            this.DESTINATIONADRESS = d.DESTINATIONADRESS;
            this.DONE = Convert.ToBoolean(d.DONE);
            this.HOUR = d.HOUR;
        }
        public static DELIVERIES FROMdtoToTable(dtoDELIVERy d)
        {
            DELIVERIES del = new DELIVERIES();
            del.DELIVERID = d.DELIVERID;
            del.IDOFDELIVER = d.IDOFDELIVER;
            del.IDOFCUSTUMER = d.IDOFCUSTUMER;
            del.DATE = d.DATE;
            del.RESPOND = d.RESPOND;
            del.SOURSEADRESS =d.SOURSEADRESS;
            del.DESTINATIONADRESS =d.DESTINATIONADRESS;
            del.DONE = d.DONE;
            del.HOUR = d.HOUR;
            return del;
        }
            public static List<dtoDELIVERy> CreateDtoList(List<DELIVERIES> LIST)
        {
            List<dtoDELIVERy> dtolist = new List<dtoDELIVERy>();
            foreach (var p in LIST)
            {
                dtoDELIVERy dtoDELIVERy = new dtoDELIVERy(p);
                dtolist.Add(dtoDELIVERy);

            }
            return dtolist;
        }


    }


}
