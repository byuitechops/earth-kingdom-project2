using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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

        public void CsvTransformer()
        {
            var counter = 0;
            foreach (var course in this.courses)
            {
                counter++;
                System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\activity02-" + counter + ".csv", string.Empty);

                dynamic data = JsonConvert.DeserializeObject(course);
                //Console.WriteLine(data);

                //List<object> json = new List<dynamic>();
                JArray json = new JArray();
                    foreach (var prop in data)
                    {   
                        //Console.WriteLine(prop);
                        json.Add(prop);
                    }
                //Console.WriteLine(json);
                foreach (var p in json){
                    Console.WriteLine(p);
                }
                using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\activity02-" + counter + ".csv", true, System.Text.Encoding.UTF8))
                {
                    var csv = new CsvWriter(writer);
                    var firstObject = json[0];

                    //Console.WriteLine(firstObject);
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
            this.CsvTransformer();
            //throw new System.NotImplementedException();
        }

        public void printReportType()
        {
            System.Console.WriteLine("My report type is {0}", reportType);
        }
    }
}
