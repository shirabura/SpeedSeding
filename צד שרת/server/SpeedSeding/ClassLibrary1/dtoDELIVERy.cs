using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class dtoDELIVERy
    {
        public long DELIVERID { get; set; }
        public long IDOFDELIVER { get; set; }
        public long IDOFCUSTUMER { get; set; }
        public DateTime DATE { get; set; }
        public int RESPOND { get; set; }
        public string SOURSEADRESS { get; set; }
        public string DESTINATIONADRESS { get; set; }
        public int DONE { get; set; }

        public dtoDELIVERy()
        {
        }
        public dtoDELIVERy(DELIVERy d)
        {
            this.DELIVERID = d.DELIVERID;
            this.IDOFDELIVER = (long)d.IDOFDELIVER;
            this.IDOFCUSTUMER = (long)d.IDOFCUSTUMER;
            this.DATE = (DateTime)d.DATE;
            this.RESPOND = (int)d.RESPOND;
            this.SOURSEADRESS = d.SOURSEADRESS;
            this.DESTINATIONADRESS = d.DESTINATIONADRESS;
            this.DONE = (int)d.DONE;

        }
        public   DELIVERy FROMdtoToTable(dtoDELIVERy d)
        {
            DELIVERy del = new DELIVERy();
            del.DELIVERID = DELIVERID;
            del.IDOFDELIVER = IDOFDELIVER;
            del.IDOFCUSTUMER = IDOFCUSTUMER;
            del.DATE = DATE;
            del.RESPOND = RESPOND;
            del.SOURSEADRESS =SOURSEADRESS;
            del.DESTINATIONADRESS =DESTINATIONADRESS;
            del.DONE = DONE;
            return del;
        }
            public static List<dtoDELIVERy> CreateDtoList(List<DELIVERy> LIST)
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
