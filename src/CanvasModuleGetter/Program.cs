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

            string api_token = System.Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");
            string endPoint = args.Length != 0 ? args[0] : "/api/v1/courses/" + courseId + "/modules?include[]=items";
            string result = await ApiCall.MakeHTTPRequest(endPoint, api_token);
            dynamic data = JsonConvert.DeserializeObject(result);
            //Console.WriteLine(data);
            //string serialized = JsonConvert.SerializeObject(data);

            switch (reportType)
            {
                case "CSV":
                    List<object> json = new List<dynamic>();
                    if (data is JArray)
                    {
                        foreach (var prop in data)
                        {
                            json.Add(prop);
                        }
                    }
                    else
                    {
                        json.Add(data);
                    }
                    CsvTransform csv = new CsvTransform();
                    csv.CsvTransformer(json);
                    break;
                case "JSON":
                    JsonTransform jTransform = new JsonTransform();
                    jTransform.JsonTransformer(data);
                    break;
                case "HTML":
                    Console.WriteLine("this is html");
                    break;
                default:
                    Console.WriteLine("Not valid file type");
                    break;
            }

        }
    }
}
