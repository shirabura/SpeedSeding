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
    class MainDelivery
    {
        public static void main(DELIVERIES d)
        {   //הפונקציה קיבלה רשומה מסוג הטבלה והופכת לסוג תצוגה
            dtoDELIVERy dtoDELIVERy = new dtoDELIVERy(d);
            List<dtoPOSSIBLEDRIVE> reqest = new List<dtoPOSSIBLEDRIVE>();
            //מפעילה את פונקציית הסינון של כל מי שסרב לבקשה
            reqest = DeliversBL.GetAllOpenRequest(dtoDELIVERy);
            //מפעילה את פונקציית בדיקת ההתאמה המוחלטת
            List<dtoPOSSIBLEDRIVE> Absolutefit = DeliversBL.Absolutefit(reqest, dtoDELIVERy);
            //אם חזר מהסינון רק רשומה אחת אז נעדכן את הנסיעה שהותאמה בדאטה בייס
            if (Absolutefit.Count == 1)
                DeliversBL.updatematch(dtoDELIVERy, Absolutefit[0]);
            //אם חזר מהסינון יותר מרשומה אחת אז נפעיל שקלולי רייטנג ומספר משלוחים
            if (Absolutefit.Count > 1)
            {
                //הפעלת פונקציית בדיקת מספר משלוחנים מינמלי מבין כל הנסיעות המתאימות
                List<dtoPOSSIBLEDRIVE> Partialfitlist = DeliversBL.Minimumnumber(Absolutefit);
                //אם חזרה בדיוק נסיעה אחת -נעדכן אותה בדאטה בייס 
                if (Partialfitlist.Count == 1)
                    DeliversBL.updatematch(dtoDELIVERy, Partialfitlist[0]);
                //אם חזר יותר מאחד-נפעיל פונקציית הרייטיג ונבחר מבין כולם את המקסימלי
                if (Partialfitlist.Count > 1)
                {
                    dtoPOSSIBLEDRIVE a = DeliversBL.calculatemaxrating(Partialfitlist);
                    //נעדכן בדאטה בייס
                    DeliversBL.updatematch(dtoDELIVERy, a);

                }
                if (Partialfitlist.Count == 0)
                    Console.WriteLine("לא נמצאו נסיעות מתאימות במערכת");


            }
            //אם מהסינון של ההתאמה המוחלטת לא חזרו בכלל רשומות מתאימות אז נפעיל את פונקציית ההתאמה החלקית  
            if (Absolutefit.Count == 0)
            {
                List<dtoPOSSIBLEDRIVE> Partialfit = DeliversBL.Partialfit(reqest, dtoDELIVERy);
                //אם חזר מהסינון רק רשומה אחת אז נעדכן את הנסיעה שהותאמה בדאטה בייס
                if (Partialfit.Count == 1)
                    DeliversBL.updatematch(dtoDELIVERy, Partialfit[0]);
                //אם חזר מהסינון יותר מרשומה אחת אז נפעיל שקלולי רייטנג ומספר משלוחים
                if (Partialfit.Count > 1)
                {
                    //הפעלת פונקציית בדיקת מספר משלוחנים מינמלי מבין כל הנסיעות המתאימות
                    List<dtoPOSSIBLEDRIVE> Partialfitlist = DeliversBL.Minimumnumber(Absolutefit);
                    //אם חזרה בדיוק נסיעה אחת -נעדכן אותה בדאטה בייס 
                    if (Partialfitlist.Count == 1)
                        DeliversBL.updatematch(dtoDELIVERy, Partialfitlist[0]);
                    //אם חזר יותר מאחד-נפעיל פונקציית הרייטיג ונבחר מבין כולם את המקסימלי
                    if (Partialfitlist.Count > 1)
                    {
                        dtoPOSSIBLEDRIVE a = DeliversBL.calculatemaxrating(Partialfitlist);
                        //נעדכן בדאטה בייס
                        DeliversBL.updatematch(dtoDELIVERy, a);

                    }
                    if (Partialfitlist.Count == 0)
                        Console.WriteLine("לא נמצאו נסיעות מתאימות במערכת");


                }



            }
        }        }
    }

