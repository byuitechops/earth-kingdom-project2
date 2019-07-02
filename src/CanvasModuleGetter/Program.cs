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

            //courses will be assigned a list of strings
            var coursesModuleLists = await ApiCall.MakeHTTPRequest(courseIds, api_token);

            //desirialize each course string into a course object.
            List<Module[]> coursesList = new List<Module[]>();
            foreach (var moduleList in coursesModuleLists)
            {
                //Console.WriteLine(moduleList);
                var courseObject = Module.FromJsonArray(moduleList);
                coursesList.Add(courseObject);
                //Console.WriteLine(courseObject);
            }

            //report will be assigned the corrosponding Report Object
            var report = ReportFactory.generateReport(reportType, coursesModuleLists, coursesList);

            //This will call the traonsform function of the IReportTransform interface
            //Every Report object will have its own definition of that function.
            report.transform();

            //print the report type for testing purposes.
            report.printReportType();

        }
    }
}
