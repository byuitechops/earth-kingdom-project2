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
                System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\activity02.csv", string.Empty);
                var firstobj = course[0];
                var firstitem = course[0].Items[0];

                JObject o = (JObject)JToken.FromObject(firstobj);
                o.Remove("items");
                o.Add("item_id", firstitem.Id);
                o.Add("title", firstitem.Title);
                o.Add("item_position", firstitem.Position);
                o.Add("indent", firstitem.Indent);
                o.Add("type", firstitem.Type);
                o.Add("module_id", firstitem.ModuleId);
                o.Add("html_url", firstitem.HtmlUrl);
                o.Add("external_url", firstitem.ExternalUrl);
                o.Add("new_tab", firstitem.NewTab);
                o.Add("item_published", firstitem.Published);
                o.Add("page_url", firstitem.PageUrl);
                o.Add("url", firstitem.Url);
                o.Add("content_id", firstitem.ContentId);

                using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\activity02.csv", true, System.Text.Encoding.UTF8))
                {
                    var csv = new CsvWriter(writer);
                    foreach (var p in o.Properties())
                    {
                        //Console.WriteLine(p.Name);
                        csv.WriteField(p.Name);
                    }
                    csv.NextRecord();

                    foreach (var mod in course)
                    {
                        foreach (var item in mod.Items)
                        {
                            string result = string.Join("", mod.PrerequisiteModuleIds);
                            //System.Console.WriteLine("result: " + result);
                            //System.Console.WriteLine(mod.PrerequisiteModuleIds);
                            // if (result == ""){
                            //     mod.PrerequisiteModuleIds = "";
                                //System.Console.WriteLine("Null");
                            //}
                    
                            csv.WriteField(mod.Id);
                            csv.WriteField(mod.Name);
                            csv.WriteField(mod.Position);
                            csv.WriteField(mod.UnlockAt);
                            csv.WriteField(mod.RequireSequentialProgress);
                            csv.WriteField(mod.PublishFinalGrade);
                            csv.WriteField(result);
                            //csv.WriteField(mod.PrerequisiteModuleIds);
                            csv.WriteField(mod.Published);
                            csv.WriteField(mod.ItemsCount);
                            csv.WriteField(mod.ItemsUrl);

                            csv.WriteField(item.Id);
                            csv.WriteField(item.Title);
                            csv.WriteField(item.Position);
                            csv.WriteField(item.Indent);
                            csv.WriteField(item.Type);
                            csv.WriteField(item.ModuleId);
                            csv.WriteField(item.HtmlUrl);
                            csv.WriteField(item.ExternalUrl);
                            csv.WriteField(item.NewTab);
                            csv.WriteField(item.Published);
                            csv.WriteField(item.PageUrl);
                            csv.WriteField(item.Url);
                            csv.WriteField(item.ContentId);

                            csv.NextRecord();
                        }
                    }

                    writer.Flush();
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
