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
            List<dtoDELIVERy> AllOpenRequest =dtoDELIVERy.CreateDtoList((db.GetDbSet<DELIVERIES>().Where(r => r.DONE == false).ToList()));

            return AllOpenRequest;
        }



        public static List<dtoDELIVERy> GetRequestbyDateHour(List<dtoDELIVERy> AllOpenRequest, dtoPOSSIBLEDRIVE p)
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

        //כאן יהיה פונקציה של גוגל מפס שבודקת את המרחקים האם הם מתאימים
        //התוצאה מכל הפונקציות הנל תהיה רשימה של נהגים שמתאימים לבקשה מסוימת ששלחתי לפי התאמה בסיסית(מקום שעה ותאריך ולא נעשו)
        //li זה הרשימה שאני מקבלת מהפונקציה הקודמת
        //public static DELIVERy ChooseDeliver(List<dtoDELIVERy> li)
        //{

        //    return li;

        //}
    }



}
