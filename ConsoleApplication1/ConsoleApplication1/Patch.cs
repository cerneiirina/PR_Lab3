using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Patch
    {
        public static async Task<HttpResponseMessage> PatchAsync(this System.Net.Http.HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            var response = await client.SendAsync(request);
                        

            return response;
        }
    }
}
