using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Newtonsoft.Json.Linq;

namespace CanvasModuleGetter
{
    public class CsvReport : IReportTransform
    {
        private List<string> courses { get; }
        private string reportType { get; }

        public CsvReport(List<string> courses)
        {
            this.courses = courses;
            reportType = "CSV";
        }

        public void CsvTransformer(List<JArray> courses)
        {
            var counter = 0;
            foreach (var course in courses)
            {
                counter++;
                System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\activity02-" + counter + ".csv", string.Empty);

                List<object> json = new List<dynamic>();
                if (course is JArray)
                {
                    foreach (var prop in course)
                    {
                        json.Add(prop);
                    }
                }
                else
                {
                    json.Add(course);
                }
                // foreach (var p in json){
                //     Console.WriteLine(p);
                // }
                using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\activity02-" + counter + ".csv", true, System.Text.Encoding.UTF8))
                {
                    var csv = new CsvWriter(writer);
                    var firstObject = json[0];

                    //   foreach (JProperty property in firstObject)
                    //       csv.WriteField(property.Name);
                    //  csv.NextRecord();



                    //  foreach (var obj in json)
                    //     {
                    //        foreach (JProperty prop in obj)
                    //         {
                    //          csv.WriteField(prop.Value.ToString());
                    //          }
                    //        csv.NextRecord();
                    //     }

                    //  writer.Flush();
                }
            }
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
