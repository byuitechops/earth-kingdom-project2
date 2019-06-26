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
            UserInput UserInput = new UserInput();
            UserInput.promptUser();
            string reportType = UserInput.getReportType();
            List<string> courseIds = UserInput.getCourseIds();
            string api_token = UserInput.getToken();

            //courses will be assigned a list of JArrays
            var courses = await ApiCall.MakeHTTPRequest(courseIds, api_token);

            // System.Console.WriteLine(data);

            // switch (reportType)
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
            //             json.Add(data);
            //         }
            //         CsvTransform csv = new CsvTransform();
            //         csv.CsvTransformer(json);
            //         break;
            //     case "JSON":
            //         JsonTransform jTransform = new JsonTransform();
            //         jTransform.JsonTransformer(data);
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
