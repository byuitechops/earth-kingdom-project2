using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public void JsonTransformer()
        {
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02.json", string.Empty);
            List<dynamic> ModuleList = new List<dynamic>();
            foreach (var course in courses)
            {
                ModuleList.Add(JsonConvert.DeserializeObject(course));
            }
            string data = JsonConvert.SerializeObject(ModuleList, Formatting.Indented);
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02.json", data);
        }

        public void transform()
        {
            this.JsonTransformer();
        }

        public void printReportType()
        {
            System.Console.WriteLine("My report type is {0}", reportType);
        }
    }
}

