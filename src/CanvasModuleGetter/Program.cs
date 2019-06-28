﻿using System;
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
            var courses = await ApiCall.MakeHTTPRequest(courseIds, api_token);

            //report will be assigned the corrosponding Report Object
            var report = ReportFactory.generateReport(reportType, courses);

            //This will call the traonsform function of the IReportTransform interface
            //Every Report object will have its own definition of that function.
            report.transform();

            //print the report type for testing purposes.
            report.printReportType();

        }
    }
}
