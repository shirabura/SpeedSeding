using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    //אפשרות ראשונה
    public class DistanceAlgorithm
    {


        public static int DistanceFrom2PointsInMinutes(string point1, string point2)
        {
            string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins="
                          + point1 + "&destinations=" + point2 + "&mode=driving&units=imperial&sensor=false&key=AIzaSyDN6hmLe4mB_RT43pToR3PtvXch2xeeBxQ";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);

                string duration = xmlDoc.DocumentElement.SelectSingleNode("//DistanceMatrixResponse/row/element/duration/value").InnerText;
                return Convert.ToInt32(duration) / 60;
            }
            catch (Exception)
            {
                return -1;
            }
            //return TravelingTime
        }
    }
}

