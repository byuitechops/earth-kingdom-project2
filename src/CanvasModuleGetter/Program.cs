using System;
using System.Threading.Tasks;
//using Newtonsoft.Json;

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

            // string api_token = System.Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");
            // string endPoint = args.Length != 0 ? args[0] : "/api/v1/courses/" + courseId;
            // string result = await ApiCall.MakeHTTPRequest(endPoint, api_token);
            // dynamic json = JsonConvert.DeserializeObject(result);
            // System.Console.WriteLine(json);
        }
    }
}
