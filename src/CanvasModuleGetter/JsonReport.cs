using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CanvasModuleGetter
{
    public class JsonReport : IReportTransform
    {
        private List<string> courses { get; }
        private string reportType { get; }

        public JsonReport(List<string> courses)
        {
            this.courses = courses;
            reportType = "JSON";
        }

        public void JsonTransformer(dynamic data)
        {
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02.json", string.Empty);
            string serialized = JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02.json", serialized);
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

