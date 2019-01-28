using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Extra Using Statements*/
using System.Net;
using System.Web.Script.Serialization;//To add this namespace we need to add a reference to the System.Web.Extension

namespace ConsumingAnApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("********* Using a Web Api ***********");
            Console.WriteLine("*************************************\n");

            List<CustomObject> data = Input();

            /*Display the data returned from the method*/
            foreach (CustomObject x in data)
            {
                Console.WriteLine("Name: {0} {1}\nGender: {2}\nRegion: {3}\n", x.name, x.surname, x.gender, x.region);
            }
            Console.ReadLine();
        }

        static List<CustomObject> Input()
        {
            /*Create a web Client to use*/
            WebClient wc = new WebClient();

            /*Use the WebClient to read in the Json string from the database*/
            string json = wc.DownloadString("https://uinames.com/api/?amount=50");

            /*We can display the json string to check it if we wanted to*/
            //Console.WriteLine("*************** Json ***************");
            //Console.WriteLine(json + "\n");

            /*I now create a list of the object made for the data by using the JavaScriptSerializer
              and use the Deserialize method to populate the list using our object we made*/
            List<CustomObject> lst = new JavaScriptSerializer().Deserialize<List<CustomObject>>(json);

            return lst;
        }
    }

    /*A custom object created to match the format of the data passedin by the json string*/
    class CustomObject
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string region { get; set; }
    }
}
