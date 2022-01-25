using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class RatingBL
    {
        static DBConection db = new DBConection();
        public static long CalculatePoint(long tz)
        {
            long point = 0;
            List<RATING> AllRating =db.GetDbSet<RATING>().Where(m => m.IDOFDELIVER == tz).ToList();
            foreach (var i in AllRating)
            {
                point +=(long) i.INTEGRITYDELIVER;
                point += (long)i.LATE;
                point += (long)i.SERVISE;
                point += (long)i.GENERAL;
                i.SamPoint = point;

            }
            foreach (var i in AllRating)
            {
                db.Execute<RATING>(i, DBConection.ExecuteActions.Update);
            }
            return point;

            //  ואז לשאול על העמודה הזאת מי המקסימום עי תור עדיפיות 

        }
    }
}
