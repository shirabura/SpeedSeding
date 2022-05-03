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
        public static dtoDELIVERy ChooseDeliver(List<dtoDELIVERy> li, dtoPOSSIBLEDRIVE p)
        {
<<<<<<< Updated upstream
            //רשימה של משלוחים שמתאימים לרשימת הנסיעות הספציפית
            List<dtoPOSSIBLEDRIVE> allPossibleshippers = new List<dtoPOSSIBLEDRIVE>();
            allPossibleshippers= PossibleDriveBL.GetAllOpenRequest(li[0]);
            //בודקת את המשלוחן המינימלי מבין כולם
            Min mincounter = new Min();
            mincounter.counter = allPossibleshippers[0].CountOfDeliveries;
            foreach (var i in allPossibleshippers)
            {
                if (i.CountOfDeliveries < mincounter.counter)
                {
                    mincounter = new Min();
                    mincounter.counter = i.CountOfDeliveries;
                }
                //אם הוא שווה למינימלי הוא יכניס אותו לרשימה של מינימלי 
                if (i.CountOfDeliveries == mincounter.counter)
                {
                    mincounter.alldeliveries.Add(i);
                }
            }
            //בודקת את הריטינג הגבוה מבין כל המשלוחנים עם מספר המשלוחים המינימלי
            Max maxrating = new Max();
            foreach (var i in mincounter.alldeliveries)
            {
                if (RatingBL.CalculatePoint(i.IDOFDELIVER) > maxrating.counter)
                {
                    maxrating = new Max();
                    maxrating.counter++;
                    maxrating.point = RatingBL.CalculatePoint(i.IDOFDELIVER);
                }
                //אם הריטינג שווה המשלוחן יכנס לרשימה של ריטיג מקסימלי (מקרה קצה ונעשה הגרלה בינהם
                if (RatingBL.CalculatePoint(i.IDOFDELIVER) == maxrating.counter)
                {
                    maxrating.counter++;
                    maxrating.allratings.Add(i);
                }
                Random r = new Random();
                r.Next(maxrating.counter);
                return r;
            }
=======
            


>>>>>>> Stashed changes
        }
    }



}
