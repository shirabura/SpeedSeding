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
   public class MainpossibledriveBL
    {
        public static dtoDELIVERy main(dtoPOSSIBLEDRIVE t)
        {
            //הופך סוג טבלה לתצוגה
            dtoPOSSIBLEDRIVE p = new dtoPOSSIBLEDRIVE();
            //מפעילה פונקצייה לחיפוש כל הבקשות המתאימות שהותאמו ולא אושרו עדיין
            List<dtoDELIVERy> AllOpenRequest = new List<dtoDELIVERy>();
            AllOpenRequest=PossibleDriveBL.GetAllOpenReqwest(p);
            //פונקצייה שבודקת את סך הנקודות של הנסיעה החדשה אל מול הנסיעה הישנה 
            return PossibleDriveBL.match(AllOpenRequest, p);

        }
        
    }

}
