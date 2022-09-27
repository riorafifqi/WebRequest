using System;

namespace WebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest();
        }

        private static void WebRequest()
        {
            const string WEBSERVICE_URL = "https://api.stormglass.io/v2/tide/extremes/point?lat=-6.500&lng=112.797";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization", "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002");

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
