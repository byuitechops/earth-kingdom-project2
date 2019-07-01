using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CanvasModuleGetter
{
    public class ApiCall
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> MakeHTTPRequest(string courseId, string api_token)
        {
            using (client)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", api_token);
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {
                    string url = "https://byui.instructure.com//api/v1/courses/" + courseId + "/modules?include[]=items";
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
        public static async Task<List<string>> MakeHTTPRequest(List<string> courseIds, string api_token)
        {
            using (client)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", api_token);
                // Call asynchronous network methods in a try/catch block to handle exceptions

                List<string> courses = new List<string>();
                try
                {
                    foreach (var courseId in courseIds)
                    {
                        string url = "https://byui.instructure.com//api/v1/courses/" + courseId + "/modules?include[]=items&per_page=100";
                        string responseBody = await client.GetStringAsync(url);
                        courses.Add(responseBody);
                    }
                    // foreach (var prop in courses)
                    //     Console.WriteLine(prop);
                    return courses;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("There was an error: " + e.Message);
                    throw;
                }
            }
        }
        //This function take a list of course ids and will return a list of JArray objects for each of the ids 
        public static async Task<List<JArray>> MakeHTTPRequestJArray(List<string> courseIds, string api_token)
        {
            using (client)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", api_token);
                // Call asynchronous network methods in a try/catch block to handle exceptions

                List<JArray> courses = new List<JArray>();
                try
                {
                    foreach (var courseId in courseIds)
                    {
                        string url = "https://byui.instructure.com//api/v1/courses/" + courseId + "/modules?include[]=items";
                        string responseBody = await client.GetStringAsync(url);
                        dynamic temp = JsonConvert.DeserializeObject(responseBody);
                        courses.Add(temp);
                    }

                    return courses;
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