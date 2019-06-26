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
                if (array is JArray)
                {
                    foreach (var prop in array)
                    {
                        json.Add(prop);
                    }
<<<<<<< HEAD
                    else
                    {
                        json.Add(array);
                    }
                    // foreach (var p in json){
                    //     Console.WriteLine(p);
                    // }
=======
                }
                else
                {
                    json.Add(array);
                }
                // foreach (var p in json){
                //     Console.WriteLine(p);
                // }
>>>>>>> d2008f0e5f8b5c50917866d5c8d3057f847ec9e4
                using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\activity02-" + counter + ".csv", true, System.Text.Encoding.UTF8))
                {
                    var csv = new CsvWriter(writer);
                    var firstObject = json[0];

<<<<<<< HEAD
                    //This is trying to loop through the first object and print out the keys.  https://stackoverflow.com/questions/36656177/loop-through-an-objects-properties-and-get-the-values-for-those-of-type-datetim?rq=1
                    foreach (PropertyInfo prop in firstObject.GetType().GetProperties()){
                        Console.WriteLine(prop.GetValue(firstObject, null));
                    }
                    //Console.WriteLine(firstObject);
                    // foreach (JProperty property in firstObject)
                    //   csv.WriteField(property.Name);
                    // csv.NextRecord();
=======
                    //   foreach (JProperty property in firstObject)
                    //       csv.WriteField(property.Name);
                    //  csv.NextRecord();
>>>>>>> d2008f0e5f8b5c50917866d5c8d3057f847ec9e4



                    //  foreach (var obj in json)
                    //     {
                    //        foreach (JProperty prop in obj)
                    //         {
                    //          csv.WriteField(prop.Value.ToString());
                    //          }
                    //        csv.NextRecord();
                    //     }

<<<<<<< HEAD
                //  writer.Flush();
=======
                    //  writer.Flush();
>>>>>>> d2008f0e5f8b5c50917866d5c8d3057f847ec9e4
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