using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOClass;


namespace BLL
{
    public class PossibleDriveBL
    {
        //חיפוש כל הבקשות המתאימות שעוד לא אושרו-לנסיעה החדשה שנוספה
        static DBConection db = new DBConection();
        //מסננת בקשות שהותאמו ועוד לא אושרו
        public static List<dtoDELIVERy> GetAllOpenReqwest(dtoPOSSIBLEDRIVE p)
        {
            //מכניסה את הנסיעה האפשרית למסד הנתונים
            POSSIBLEDRIVE d = new POSSIBLEDRIVE();
            d = dtoPOSSIBLEDRIVE.FromdtoToTable(p);
            db.Execute<POSSIBLEDRIVE>(d, DBConection.ExecuteActions.Insert);
            //שליפת הבקשות ממסד הנתונים
            List<dtoDELIVERy> AllOpenRequest = dtoDELIVERy.CreateDtoList((db.GetDbSet<DELIVERIES>().Where(r => r.IDOFDELIVER != null && r.DONE == false)).ToList()).ToList();
            return AllOpenRequest;
        }
        //הפונקצייה בודקת את סך הנקודות של הנסיעה החדשה אל מול הנסיעה הישנה
        public static dtoDELIVERy match(List<dtoDELIVERy> AllOpenRequest, dtoPOSSIBLEDRIVE p)
        {
            foreach (dtoDELIVERy d in AllOpenRequest)
            {
                POSSIBLEDRIVE prevDrive = new POSSIBLEDRIVE();
                prevDrive = db.GetDbSet<POSSIBLEDRIVE>().Where(pd=>pd.KODOFDRIVE == d.IDOFDELIVER).FirstOrDefault(); 

                float prepoint = 0;
                float newpoint = 0;
                newpoint = checkpoint(p, d);
                prepoint = checkpoint(new dtoPOSSIBLEDRIVE( prevDrive) , d);
                //אם סכום הניקוד של הנסיעה הישנה יותר קטן אז הדאטה בייס יעודכן בפרטי הנסיעה החדשה
                if (prepoint > newpoint)
                {
                    return updatematch(d, p);
                    
                }
               
            }
            return null;
        }
        //פונקצייה שמחשבת ניקוד למשלוחן בהתאם לבקשה מסוימת
        public static float checkpoint(dtoPOSSIBLEDRIVE p, dtoDELIVERy d)
        {
            int point = 0;
            int date = 0;
            int hour = 0;
            int Sourceaddress = 0;
            int Destinationaddress = 0;


            TimeSpan diff = d.DATE - p.DATE;
            date = (int)Math.Ceiling(diff.TotalDays);
            Sourceaddress = DistanceAlgorithm.DistanceFrom2PointsInMinutes(p.SOURSEADRESS, d.SOURSEADRESS);
            Destinationaddress = DistanceAlgorithm.DistanceFrom2PointsInMinutes(p.DESTINATIONADRESS, d.DESTINATIONADRESS);
            point = date + Sourceaddress + Destinationaddress;
            return point;
        }
        //פונקצייה שמחזירה את היסטורית המשלוחים של משתמש מסוים
        public static List<dtoDELIVERy> viewhistory(long tz)
        {
            List<dtoDELIVERy> history = new List<dtoDELIVERy>();
            history = dtoDELIVERy.CreateDtoList(db.GetDbSet<DELIVERIES>().Where(r => r.IDOFDELIVER == tz).ToList());
            return history;
        }
        //פונקצייה שמעדכנת בדאטה בייס
        //ומחזירה נסיעה מתאימה
        public static dtoDELIVERy updatematch(dtoDELIVERy p, dtoPOSSIBLEDRIVE match)
        {
            DELIVERIES d = new DELIVERIES();
            d = dtoDELIVERy.FROMdtoToTable(p);
            p.IDOFDELIVER = match.KODOFDRIVE;
            db.Execute<DELIVERIES>(d, DBConection.ExecuteActions.Update);
            dtoDELIVERy a = new dtoDELIVERy(d);
            return a;
        }
        //פונקצייה שמעדכנת בדאטה בייס שהבקשה אושרה והמשלוח עתיד להתקיים
        //ומחזירה את מספר הטלפון של הלקוח המתאים
        public static string UpdetConfirmation(dtoDELIVERy p)
        {
            string CustumerPhone;
            DELIVERIES d = new DELIVERIES();
            d = dtoDELIVERy.FROMdtoToTable(p);
            d.DONE = true;
            db.Execute<DELIVERIES>(d, DBConection.ExecuteActions.Update);
            USERS Custumer = new USERS();
            Custumer = db.GetDbSet<USERS>().Where(r => r.Id == p.IDOFDELIVER).First();
            CustumerPhone = Custumer.phone;
            return CustumerPhone;
        }
        //החזרת המספר טלפון של המשלוחן המתאים
        public static string returnphone(dtoPOSSIBLEDRIVE p)
        {
            string deliverPhone;
            USERS deliver = new USERS();
            deliver = db.GetDbSet<USERS>().Where(r => r.Id == p.IDOFDELIVER).First();
            deliverPhone = deliver.phone;
            return deliverPhone;

        }
    }
       
}
