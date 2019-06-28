using System.Collections.Generic;

namespace CanvasModuleGetter
{
    public class HtmlReport : IReportTransform
    {
        private List<string> courses { get; }
        private string reportType { get; }


        public HtmlReport(List<string> courses)
        {
            this.courses = courses;
            reportType = "HTML";
        }

        public void transform()
        {
            //throw new System.NotImplementedException();
        }

        public void printReportType()
        {
            System.Console.WriteLine("My report type is {0}", reportType);
        }
    }
}