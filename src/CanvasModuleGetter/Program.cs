using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            string token = up.getToken();
            string endPoint = "/api/v1/courses/" + courseId + "/modules?includes[]=items";
            string result = await ApiCall.MakeHTTPRequest(endPoint, token);
            dynamic json = JsonConvert.DeserializeObject(result);
            Console.WriteLine(json);
        }
    }
}
