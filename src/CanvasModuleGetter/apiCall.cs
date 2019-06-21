using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CanvasModuleGetter
{
    public class ApiCall
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> MakeHTTPRequest(string endPoint, string api_token)
        {
            using (client)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", api_token);
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {
                    string url = "https://byui.instructure.com/" + endPoint;
                    string responseBody = await client.GetStringAsync(url);

                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("There was an error: " + e.Message);
                    throw;
                }
            }
        }
    }
}