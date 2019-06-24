using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CanvasModuleGetter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UserInput up = new UserInput();
            up.promptUser();
            string reportType = up.getReportType();
            string courseId = up.getCourseId();
            string api_token = up.getToken();
            
            string result = await ApiCall.MakeHTTPRequest(courseId, api_token);
            dynamic data = JsonConvert.DeserializeObject(result);
            System.Console.WriteLine(data);

            List <string> courseIds = new List<string>(new string[] {"80", "80", "80"});
            var result1 = await ApiCall.MakeHTTPRequest(courseIds, api_token);
            System.Console.WriteLine(result1);
            
            System.Console.WriteLine(data);

            // switch(reportType)
            // {
            //     case "CSV":
            //         List<object> json = new List<dynamic>();
            //         if (data is JArray)
            //         {
            //             foreach (var prop in data)
            //             {
            //                 json.Add(prop);
            //             }
            //         }
            //         else
            //         {
            //              json.Add(data);
            //         }
            //         CsvTransform.CsvTransformer(json);
            //         break;
            //     case "JSON":
            //         Console.WriteLine("this is json");
            //         break;
            //     case "HTML":
            //         Console.WriteLine("this is html");
            //         break;
            //     default:
            //         Console.WriteLine("Not valid file type");
            //         break;
            // }
        }
    }
}
