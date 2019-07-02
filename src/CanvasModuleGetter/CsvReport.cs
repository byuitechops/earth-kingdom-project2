using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace CanvasModuleGetter
{
    public class CsvReport : IReportTransform
    {
        private List<string> courses { get; }
        private List<Module[]> coursesList { get; }
        private string reportType { get; }

        public CsvReport(List<string> courses, List<Module[]> coursesList)
        {
            this.courses = courses;
            this.coursesList = coursesList;
            reportType = "CSV";
        }

        public void CsvTransformer()
        {
            var counter = 0;
            foreach (var course in this.coursesList)
            {
                /**********************************************
                 * TODO: Change these foreach loops to firstly 
                 * take a Module, then foreach item in that 
                 * module make a csv entry
                 **********************************************/
                counter++;
                System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02-" + counter + ".csv", string.Empty);
                var firstobj = course[0];

                JObject o = (JObject)JToken.FromObject(firstobj);
                o.Remove("Items");


                //Console.WriteLine(course);
                //dynamic data = JsonConvert.DeserializeObject(course);
                //Console.WriteLine(data);

                //List<object> json = new List<dynamic>();
                // JArray json = new JArray();
                //     foreach (var prop in data)
                //     {   
                //         //Console.WriteLine(prop);
                //         json.Add(prop);
                //     }
                //Console.WriteLine(json);
                // foreach (var p in json){
                //     Console.WriteLine(p);
                // }
                using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\output\activity02-" + counter + ".csv", true, System.Text.Encoding.UTF8))
                {
                    var csv = new CsvWriter(writer);
                    foreach (var p in o.Properties())
                    {
                        Console.WriteLine(p.Name);
                        csv.WriteField(p.Name);
                    }
                    csv.NextRecord();

                    // foreach (var v in o.PropertyValues()){
                    //     csv.WriteField(v.Value);
                    //     //csv.NextRecord();
                    // }
                    // csv.NextRecord();
                    // var firstObject = json[0];

                    //Console.WriteLine(firstObject);
                    //   foreach (JsonProperty property in course)
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
