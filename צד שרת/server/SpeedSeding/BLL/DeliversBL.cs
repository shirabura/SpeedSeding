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
            //הכנסת הבקשה למסד הנתונים
            DELIVERIES d = new DELIVERIES();
            d = dtoDELIVERy.FROMdtoToTable(p);
            db.Execute<DELIVERIES>(d, DBConection.ExecuteActions.Insert);
            //שליפת כל הנסיעות ממסד הנתונים
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
                    if (item.SOURSEADRESS == p.SOURSEADRESS && item.DESTINATIONADRESS == p.DESTINATIONADRESS)
                        AllOpenRequest.Add(item);
            }

            return AllOpenRequest;
        }
        //בדיקת התאמה חלקית
        public static List<dtoPOSSIBLEDRIVE> Partialfit(List<dtoPOSSIBLEDRIVE> reqest, dtoDELIVERy p)
        {
            List<dtoPOSSIBLEDRIVE> Partialfitlist = new List<dtoPOSSIBLEDRIVE>();
            int DistanceBetweenSourceAddresses, DistanceBetweenDestinationAddresses;
            Min min = new Min();
            foreach (var item in reqest)
            {
                //כאן תהיה פונקצצית חישוב מרחקים של גוגל מפות
                DistanceBetweenSourceAddresses = DistanceAlgorithm.DistanceFrom2PointsInMinutes(item.SOURSEADRESS, p.SOURSEADRESS);
                DistanceBetweenDestinationAddresses = DistanceAlgorithm.DistanceFrom2PointsInMinutes(item.DESTINATIONADRESS, p.DESTINATIONADRESS);
                if (DistanceBetweenSourceAddresses + DistanceBetweenDestinationAddresses < min.counter)
                {
                    Min newmin = new Min();
                    newmin.counter = DistanceBetweenSourceAddresses + DistanceBetweenDestinationAddresses;
                    min.counter = newmin.counter;
                    newmin.alldeliveries.Add(item);
                }
                if (DistanceBetweenSourceAddresses + DistanceBetweenDestinationAddresses == min.counter)
                {
                    min.alldeliveries.Add(item);
                }


            }
            Partialfitlist = min.alldeliveries;
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
        //פונקציית ההתאמה(מעדכנים אצל הבקשה את הקוד נסיעה  של המשלוחן המתאים)
        //ומחזירים את המשלוחן המתאים
        public static USERS updatematch(dtoDELIVERy p, dtoPOSSIBLEDRIVE match)
        {
            DELIVERIES d = new DELIVERIES();
            d=dtoDELIVERy.FROMdtoToTable(p);
            p.IDOFDELIVER = match.KODOFDRIVE;
            USERS Custumer = new USERS();
            Custumer = db.GetDbSet<USERS>().Where(r => r.Id == match.IDOFDELIVER).First();
            d.IDOFDELIVER = Custumer.Id;
            return Custumer;
            db.Execute<DELIVERIES>(d, DBConection.ExecuteActions.Update);
            return Custumer;
        }
        //המשתמש יכול להגיב על משלוח שנעשה לו
        public static List<dtoDELIVERy> Responsetodelivery(long deliverId)
        {

             return null;
        }

    }
}
