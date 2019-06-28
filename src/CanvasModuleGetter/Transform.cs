using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace CanvasModuleGetter
{
    // I figured that we could use the Factory Pattern in our program. Not sure if it's a good idea or not.
    interface Transform
    {
        //public void transformer(dynamic data);
    }

    public class CsvTransform : Transform
    {
        public void CsvTransformer(List<JArray> courses)
        {
            var counter = 0;
            foreach (var array in courses)
            {
                counter++;
                System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\activity02-" + counter + ".csv", string.Empty);

                List<object> json = new List<dynamic>();
                
                    foreach (var prop in array)
                    {
                        json.Add(prop);
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
    }

    class JsonTransform : Transform
    {
        public void JsonTransformer(dynamic data)
        {
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02.json", string.Empty);
            string serialized = JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\output\activity02.json", serialized);
        }
    }

    class HtmlTransform : Transform
    {

    }
}
