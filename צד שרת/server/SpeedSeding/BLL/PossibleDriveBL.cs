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
            List<dtoDELIVERy> AllOpenRequest = dtoDELIVERy.CreateDtoList((db.GetDbSet<DELIVERIES>().Where(r => r.IDOFDELIVER != null && r.DONE == false)).ToList()).ToList();
            return AllOpenRequest;
        }
        //הפונקצייה בודקת את סך הנקודות של הנסיעה החדשה אל מול הנסיעה הישנה
        public static void match(List<dtoDELIVERy> AllOpenRequest, dtoPOSSIBLEDRIVE p)
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
                    DeliversBL.updatematch(d, p);
                }
            }
        }
        //פונקצייה שמחשבת ניקוד למשלוחן בהתאם לבקשה מסוימת
        public static float checkpoint(dtoPOSSIBLEDRIVE p, dtoDELIVERy d)
        {
            float point = 0;
            float date = 0;
            float hour = 0;
            float Sourceaddress = 0;
            float Destinationaddress = 0;


            TimeSpan diff = d.DATE - p.DATE;
            date = (int)Math.Ceiling(diff.TotalDays);
            //Sourceaddress=חישוב גוגל מפות
            //Destinationaddress=חישוב גוגל מפות
            point = date + Sourceaddress + Destinationaddress;
            return point;
        }



    }
}
