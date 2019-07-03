using System;
using System.Collections.Generic;

namespace CanvasModuleGetter
{
    public static class ReportFactory
    {
        public static IReportTransform generateReport(string reportType, List<string> courses, List<Module[]> coursesList) //consider Generic. Talk more with Josh. Also consider enum for reportType
        {
            IReportTransform reportObject;

            //Create the report object according to the users request(reportType)
            switch (reportType)
            {
                case "CSV":
                    reportObject = new CsvReport(courses, coursesList);
                    break;
                case "JSON":
                    reportObject = new JsonReport(courses);
                    break;
                case "HTML":
                    reportObject = new HtmlReport(courses, coursesList);
                    break;
                default:
                    Console.WriteLine("Not valid file type");
                    reportObject = null;
                    break;
            }
            return reportObject;
        }
    }
}