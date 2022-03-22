using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Model;
using DAL;
using DTOClass;
namespace BL
{
    public class DeliversBL
    {
        static DBConection db = new DBConection();
        //חיפוש כל החבילות שמתאימות למשלוחן
        public static List<dtoDELIVERy> GetAllOpenRequest(dtoPOSSIBLEDRIVE p)
        {
            List<dtoDELIVERy> AllOpenRequest =dtoDELIVERy.CreateDtoList((db.GetDbSet<DELIVERIES>().Where(r => r.DONE == false).ToList()));
            List<dtoDELIVERy> RequestbyDateHour = new List<dtoDELIVERy>();
            List<dtoDELIVERy> allPossiblerequest = new List<dtoDELIVERy>();

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
            return allPossiblerequest;
        }
       
        //התוצאה מכל הפונקציות הנל תהיה רשימה של משלוחים שמתאימים לנסיעה מסוימת ששלחתי לפי התאמה בסיסית(מקום שעה ותאריך ולא נעשו)
        //li זה הרשימה שאני מקבלת מהפונקציה הקודמת
        public static DELIVERy ChooseDeliver(List<dtoDELIVERy> li, dtoPOSSIBLEDRIVE p)
        {
            //בודקת האם המשלוחן קיבל כבר משלוחים לנסיעה זו
            if (p.CountOfDeliveries == 0)
            {
              //אם לא קיבל אז הוא מקבל את כל הרשימה המתאימה וצריך לאשר את המשלוחים שרוצה
                return li;
            }
            foreach (var i in li)
            {
                PossibleDriveBL.GetAllOpenRequest(i);
            }
           return li;

        }
    }



}
