using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net;
using System.IO;
using System.Text;
using System.Data;


namespace trial
{
    class calculate
    {
        DBConection dBConection = new DAL.DBConection();



        public void a()
        {
            string origin = "Oberoi Mall, Goregaon";
            string destination = "Infinity IT Park, Malad East";
            string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&key=AIzaSyCPl5kXqVtO4GELuj4DqMQGPhnXNJ7X2wA";
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                   // dsResult.ReadXml(reader);
                    Console.WriteLine(dsResult.Tables["duration"].Rows[0]["text"].ToString());
                    Console.WriteLine(dsResult.Tables["distance"].Rows[0]["text"].ToString());



                }




            }
        }
    }
}
