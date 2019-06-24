using System;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CanvasModuleGetter
{
    // I figured that we could use the Factory Pattern in our program. Not sure if it's a good idea or not.
    interface Transform
    {

    }

    public class CsvTransform : Transform
    {
        public static void CsvTransformer(List <dynamic> json) {
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\activity02.csv",string.Empty);


            using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\activity02.csv", true, System.Text.Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                var firstObject = json[0];

                foreach (JProperty property in firstObject)
                    csv.WriteField(property.Name);
                csv.NextRecord();



                foreach (var obj in json)
                {
                    foreach (JProperty prop in obj)
                    {
                        csv.WriteField(prop.Value.ToString());
                    }
                    csv.NextRecord();
                }

                writer.Flush();
            }
        }
    }

    class JsonTransform : Transform
    {

    }

    class HtmlTransform : Transform
    {

    }
} 