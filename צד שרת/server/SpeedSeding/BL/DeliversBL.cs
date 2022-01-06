using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTOClass;
namespace BL
{
    public class DeliversBL
    {
        static DBConection db = new DBConection();
        public static List<dtoDELIVERy> GetAllOpenRequest()
        {
            List<dtoDELIVERy> AllOpenRequest = db.GetDbSet<DELIVERy>().Where(r => r.DONE == false).tolist();

            return AllOpenRequest;
        }
        public static List<dtoDELIVERy> GetRequestbyDateHour(List<dtoDELIVERy> AllOpenRequest , dtoPOSSIBLEDRIVE p)
        {
            List<dtoDELIVERy> RequestbyDateHour = new List<dtoDELIVERy>();

            foreach (var i in AllOpenRequest)
            {
                if (i.DATE == p.DATE && i.HOUR == p.HOUR)
                {
                    RequestbyDateHour.Add(i);
                }

            }
           return RequestbyDateHour;
        }

    }
}
