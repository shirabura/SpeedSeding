﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    //אפשרות ראשונה
    internal class DistanceAlgorithm
    {


        const double PIx = 3.141592653589793;
        const double RADIO = 6378.16;

        /// <summary>
        /// This class cannot be instantiated.
        /// </summary>
        private DistanceAlgorithm() { }

        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        /// <param name="x">Degrees</param>
        /// <returns>The equivalent in radians</returns>
        public static double Radians(double x)
        {
            return x * PIx / 180;
        }

        /// <summary>
        /// Calculate the distance between two places.
        /// </summary>
        /// <param name="lon1"></param>
        /// <param name="lat1"></param>
        /// <param name="lon2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static double DistanceBetweenPlaces(
            double lon1,
            double lat1,
            double lon2,
            double lat2)
        {
            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return (angle * RADIO) * 0.62137;//distance in miles
        }


    }
    //אפשרות שניה
          {



             string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin.Text + "&destinations=" + Label9.Text + "&key=The Distance Matrix API is a service that provides travel distance and time for a matrix of origins and destinations. The API returns information based on the recommended route between start and end points, as calculated by the Google Maps API, and consists of rows containing duration and distance values for each pair.
";
             WebRequest request = WebRequest.Create(url);
             using (WebResponse response = (HttpWebResponse) request.GetResponse())
             {
              using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
               {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    //lblOriginAddress.Text = dsResult.Tables["DistanceMatrixResponse"].Rows[0]["origin_address"].ToString();
                    //lblDestinationAddress.Text = dsResult.Tables["DistanceMatrixResponse"].Rows[0]["destination_address"].ToString();
                    duration.Text = dsResult.Tables["duration"].Rows[0]["text"].ToString();
                   distance.Text = dsResult.Tables["duration"].Rows[0]["value"].ToString() + dsResult.Tables["distance"].Rows[0]["text"].ToString();
               }
             }
 

          }
          //אפשרות שלישית
          {
       protected void Page_Load(object sender, EventArgs e)
    {
        string origin = "Oberoi Mall, Goregaon";
        string destination = "Infinity IT Park, Malad East";
        string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&key=The Distance Matrix API is a service that provides travel distance and time for a matrix of origins and destinations. The API returns information based on the recommended route between start and end points, as calculated by the Google Maps API, and consists of rows containing duration and distance values for each pair.
";
        WebRequest request = WebRequest.Create(url);
        using (WebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                DataSet dsResult = new DataSet();
                dsResult.ReadXml(reader);
                duration.Text = dsResult.Tables["duration"].Rows[0]["text"].ToString();
                distance.Text = dsResult.Tables["distance"].Rows[0]["text"].ToString();
            }
        }
    }

}




}

