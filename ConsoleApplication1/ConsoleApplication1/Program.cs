using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
       

        public enum Methods{
            Get = 0,
            Post = 1,
            Put = 2 ,
            Delete = 3,
            Patch = 4 
        }



        public static async void CustomRequest(string uri, Methods method)
        {
            var client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("id", "0"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(values);
            dynamic result;

            switch (method)
            {
                case Methods.Get: result = client.GetAsync(uri).Result; break;
                case Methods.Post: result = client.PostAsync(uri, content).Result; break;
                case Methods.Delete: result = client.DeleteAsync(uri).Result; break;
                case Methods.Put: result = client.PutAsync(uri, content).Result; break;
                case Methods.Patch: result = await Patch.PatchAsync(client, uri, content); break;
                default: result = null; break;
            }
            string jsonContent = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(jsonContent);
            Console.WriteLine(result.StatusCode);

        }




        static void Main(string[] args)
        {
            string uri2 = @"http://www.mocky.io";
            string uri = @"http://httpbin.org";


            Program.CustomRequest(uri + @"/get", Methods.Get);
            Program.CustomRequest(uri + @"/post", Methods.Post);
            Program.CustomRequest(uri2 + @"udd/5ca5e4ba3300008c532eaa13", Methods.Put);
            Program.CustomRequest(uri + @"/delete", Methods.Delete);
            Program.CustomRequest(uri + @"/patch", Methods.Patch);



            Console.ReadLine();
        }
    }
}
