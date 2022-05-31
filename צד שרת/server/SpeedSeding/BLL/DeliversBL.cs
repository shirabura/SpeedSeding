using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DTOClass;
namespace BLL
{
    public class DeliversBL
    {
        static DBConection db = new DBConection();
        //בשלב הראשון מתבצע סינון של המשלוחנים שכבר סירבו לבקשה ( אם קיימים)
        public static List<dtoPOSSIBLEDRIVE> GetAllOpenRequest(dtoDELIVERy p)
        {
            List<dtoPOSSIBLEDRIVE> AllOpenRequest = dtoPOSSIBLEDRIVE.CreateDtoList((db.GetDbSet<POSSIBLEDRIVE>().ToList()));
            List<NOTCONFIRM> NOTCONFIRMs = db.GetDbSet<NOTCONFIRM>();
            List<dtoPOSSIBLEDRIVE> reqest = new List<dtoPOSSIBLEDRIVE>();
            bool flag = false;
            foreach (var i in AllOpenRequest)
            {
                foreach (var item in NOTCONFIRMs)
                {
                    if (item.PossibleDriveId == i.KODOFDRIVE && item.DeliveryId == p.DELIVERID)
                        flag = true;
                }
                if (flag == false)
                    reqest.Add(i);
            }
            return reqest;
        }
        //בשלב השני מתבצע חיפוש המשלוחן המתאים ביותר:
        //ראשית,תתבצע בדיקת התאמה מוחלטת
        public static List<dtoPOSSIBLEDRIVE> Absolutefit(List<dtoPOSSIBLEDRIVE> reqest, dtoDELIVERy p)
        {
            List<dtoPOSSIBLEDRIVE> AllOpenRequest = new List<dtoPOSSIBLEDRIVE>();
            foreach (var item in reqest)
            {
                if (item.DATE == p.DATE && item.HOUR == p.HOUR)
                    //if() כאן תהיה פונקצייה של גוגל מפות שתבדוק את התאמת המקומות של כתובות המקור אל מול כתובות היעד
                    AllOpenRequest.Add(item);
            }

            return AllOpenRequest;
        }
        //שנית תתבצע בדיקת התאמה חלקית
        public static List<dtoPOSSIBLEDRIVE> Partialfit(List<dtoPOSSIBLEDRIVE> AllOpenRequest, dtoDELIVERy p)
        {
            List<dtoPOSSIBLEDRIVE> Partialfitlist = new List<dtoPOSSIBLEDRIVE>();
            foreach (var item in AllOpenRequest)
            {
                //כאן תהיה פונקצצית חישוב מרחקים של גוגל מפות
                //  נכניס לרשימה של Partialfitlist את כל הנסיעות המתאימות עם המרחק המינימלי
            }
            return Partialfitlist;

        }
        //במידה ולאחר ההתאמה המוחלטת או החלקית נשיג כמה משלוחנים באותה רמה -נבצע בדיקת הסתברות
        //חיפוש כל הנסיעות עם מספר משלוחים מינימלי
        public static List<dtoPOSSIBLEDRIVE> Minimumnumber(List<dtoPOSSIBLEDRIVE> Partialfitlist)
        {
            Min mincounter = new Min();
            foreach (var i in Partialfitlist)
            {
                if (i.CountOfDeliveries < mincounter.counter)
                {
                    mincounter = new Min();
                    mincounter.counter = i.CountOfDeliveries;
                }
                if (i.CountOfDeliveries == mincounter.counter)
                {
                    mincounter.alldeliveries.Add(i);
                }
            }
            return mincounter.alldeliveries;
        }
        //חישוב רייטינג מקסימלי מבין כל הנסיעות עם מספר המשלוחים המינימלי
        public static dtoPOSSIBLEDRIVE calculatemaxrating(List<dtoPOSSIBLEDRIVE> mincounter)
        {
            Max maxrating = new Max();
            int w;
            foreach (var i in mincounter)
            {
                if (RatingBL.CalculatePoint(i.IDOFDELIVER) > maxrating.counter)
                {
                    maxrating = new Max();
                    maxrating.counter++;
                    maxrating.point = RatingBL.CalculatePoint(i.IDOFDELIVER);
                }
                if (RatingBL.CalculatePoint(i.IDOFDELIVER) == maxrating.counter)
                {
                    maxrating.counter++;
                    maxrating.allratings.Add(i);
                }

            }
            //במידה וגם לאחר כל הסינונים הנל ישארו מספר נסיעות באותה הרמה-תתבצע בינהם הגרלה
            if (maxrating.counter > 1)
            {
                Random r = new Random();
                w = r.Next(maxrating.counter);
                return maxrating.allratings[w];
            }
            return maxrating.allratings[0];
        }
        //פונקציית השיבוץ(מעדכנים אצל הבקשה את הקוד נסיעה  של המשלוחן המתאים)
        public static void updatematch(dtoDELIVERy p, dtoPOSSIBLEDRIVE match)
        {
            DELIVERIES d = new DELIVERIES();
            d = p.FROMdtoToTable(p);
            p.IDOFDELIVER = match.KODOFDRIVE;
            db.Execute<DELIVERIES>(d, DBConection.ExecuteActions.Update);
        }
        //המשתמש יכול להגיב על משלוח שנעשה לו
        public static void Responsetodelivery()
        {
        }
    }
}
