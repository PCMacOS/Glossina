using System;
using System.Globalization;
//If use the first method for the request then enable this two 'using' and comment the other two.
using System.IO;
using System.Net;
//If use the second method for the request then enable this two 'using' and comment the other two.
//using System.Threading.Tasks;
//using System.Net.Http;

namespace Glossina
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give the site you want to cause insomnia without 'http://' : ");
            var url = Console.ReadLine();
            bool siteExist;
            siteExist = PingSite(url);
            var rnd = new Random(); //Get starting random method from system time
            var timeToStart = rnd.Next(1, 20); // Get the random time
            do
            {
                
                if (!siteExist)
                {
                    Console.WriteLine("Give the site you want to cause insomnia without 'http://' : ");
                    url = Console.ReadLine();
                    siteExist = PingSite(url);
                }

                var pingCount = 0;
                DateTime localDate;
                
                if (siteExist)
                {
                    var startTimeSpan = TimeSpan.Zero;
                    var periodTimeSpan = TimeSpan.FromMinutes(timeToStart);
                    var timer = new System.Threading.Timer((e) => //Do this evrey timeToStart Minutes
                    {
                        siteExist = PingSite(url);
                        RequestSite(url);
                        pingCount++;
                        localDate = DateTime.Now;
                        Console.WriteLine("Requested to {2} {0} times at {1}. The period Time is {3} minutes.", pingCount,
                            localDate.ToString(CultureInfo.InvariantCulture), url, timeToStart);
                        timeToStart = rnd.Next(1, 20); // Get the random time
                        periodTimeSpan = TimeSpan.FromMinutes(timeToStart);
                    }, null, startTimeSpan, periodTimeSpan);

                    Console.WriteLine("If you want to stop the application, input 'stop'.");
                    string stopPing;
                    do
                    {
                        stopPing = Console.ReadLine();
                    } while (stopPing!="stop");
                    siteExist = false;
                    Environment.Exit(0);
                }

            } while (true);
        }

        static bool PingSite(string url)
        {
            var ping = new System.Net.NetworkInformation.Ping();

            try
            {
                var result = ping.Send(url);
            }
            catch
            {
                Console.WriteLine("This host is not available, try again.");
                return false;
            }
            return true;
        }

        //If the request to url with the size of 32.1KB for 70 times the maximum RAM is 4.2MB. At most times the RAM it uses is 3.5MB and for some issues reset and do it all again to 2.6MB.
        static void RequestSite(string url)
        {

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + url);
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string response = reader.ReadToEnd();
                    response = null;
                }
            }

        }

        //For this method, if the request to url with the size of 32.1KB for 65 times the maximum RAM is 5.7MB and probably get more RAM.At most times the RAM it uses is 4.6MB and for some issues reset and do it all again to 3.7MB.
        /*static async Task RequestSite(string url)
        {

            HttpClient client = new HttpClient();
            var responseString = await client.GetStringAsync("http://" + url);

        }
        */

    }
}
