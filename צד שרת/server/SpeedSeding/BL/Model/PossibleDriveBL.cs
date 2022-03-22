using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOClass;


namespace BL.Model
{
    public class PossibleDriveBL
    {
        static DBConection db = new DBConection();
        //חיפוש כל המשלוחנים שמתאימים לבקשה מסוימת
        public static List<dtoPOSSIBLEDRIVE> GetAllOpenRequest(dtoDELIVERy p)
        {
            List<dtoPOSSIBLEDRIVE> AllOpenRequest = dtoPOSSIBLEDRIVE.CreateDtoList((db.GetDbSet<POSSIBLEDRIVE>().ToList()));
            List<dtoPOSSIBLEDRIVE> RequestbyDateHour = new List<dtoPOSSIBLEDRIVE>();
            List<dtoPOSSIBLEDRIVE> allPossibleshippers = new List<dtoPOSSIBLEDRIVE>();
            foreach (var i in AllOpenRequest)
            {
                if (i.DATE == p.DATE && i.HOUR == p.HOUR)
                {
                    RequestbyDateHour.Add(i);
                }
            }
            foreach (var i in RequestbyDateHour)
            {
                //כאן יהיה סינון נוסף של גוגל מפס שבודקת את המרחקים האם הם מתאימים
            }

            return allPossibleshippers;
        }
        //התוצאה מכל הפונקציות הנל תהיה רשימה של משלוחים שמתאימים לנסיעה מסוימת ששלחתי לפי התאמה בסיסית(מקום שעה ותאריך ולא נעשו

    }   
}
