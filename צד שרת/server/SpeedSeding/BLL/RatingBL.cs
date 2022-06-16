using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOClass;

namespace BLL
{
    public class RatingBL
    {
        static DBConection db = new DBConection();
        public static long CalculatePoint(long tz)
        {
            long point = 0;
            List<RATING> AllRating = db.GetDbSet<RATING>().Where(m => m.IDOFDELIVER == tz).ToList();
            foreach (var i in AllRating)
            {
                point += (long)i.INTEGRITYDELIVER;
                point += (long)i.LATE;
                point += (long)i.SERVISE;
                point += (long)i.GENERAL;
            }

            foreach (var i in AllRating)
            {
                i.SamPoint = point;
            }

            foreach (var i in AllRating)
            {
                db.Execute<RATING>(i, DBConection.ExecuteActions.Update);
            }
            return point;

        }
        //פונקציה שמעדכנת במסד הנתונים את  טופס התגובה
        public static void Responsetodelivery(long tz, dtoRATING r, long deliverid)
        {
            RATING t = new RATING();
            t = dtoRATING.FROMdtoToTable(r);
            t.IDOFDELIVER = tz;
            t.DELIVERYID = deliverid;
            db.Execute<RATING>(t, DBConection.ExecuteActions.Insert);
            t.SamPoint = RatingBL.CalculatePoint(tz);


        }
    }
}
