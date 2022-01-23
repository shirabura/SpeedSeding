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
        public static int CalculatePoint(long tz)
        {
            int point = 0;
            List<RATING> AllRating =db.GetDbSet<RATING>().Where(m => m.IDOFDELIVER == tz).ToList();
            foreach (var i in AllRating)
            {
                point +=(int) i.INTEGRITYDELIVER;
                point += (int)i.LATE;
                point += (int)i.SERVISE;
                point += (int)i.GENERAL;

            }
            return point;
            // איך מכניסים את שקלול הריטינג פויינט לטבלה ואז לשאול על העמודה הזאת מי המקסימום 

        }
    }
}
