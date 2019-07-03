using System;
using System.Collections.Generic;
using System.IO;

namespace CanvasModuleGetter
{
    public class HtmlReport : IReportTransform
    {
        private List<string> courses { get; }
        private List<Module[]> coursesList { get; }
        private string reportType { get; }


        public HtmlReport(List<string> courses, List<Module[]> coursesList)
        {
            this.courses = courses;
            this.coursesList = coursesList;
            reportType = "HTML";
        }

        public string getHtmlHead()
        {
            string textFile = "./HtmlFiles/head.html";
            string headText = File.ReadAllText(textFile);
            // Console.WriteLine(headText);
            return headText;
        }

        public string getHtmlScripts()
        {
            string textFile = "./HtmlFiles/scripts.html";
            string scriptsText = File.ReadAllText(textFile);
            // Console.WriteLine(scriptsText);
            return scriptsText;
        }

        public string makeHtmlContent()
        {
            var content = "<body>\n";
            foreach (Module[] mods in coursesList)
            {
                foreach (var mod in mods)
                {
                    content += makeModule(mod);
                }
            }

            content += "</body>\n</html>";
            // Console.WriteLine(content);
            return content;
        }

        public string makeModule(Module mod)
        {
            var pub = mod.Published == true ? "published" : "unpublished";
            string content = $"<div class=\"container\">\n<h3 class=\"module\">{mod.Name} - {mod.Id}<span class=\"{pub}\"></span></h3>\n";
            if (mod.PrerequisiteModuleIds.Length != 0) content += $"Prerequisite Module Ids: " + string.Join(", ", mod.PrerequisiteModuleIds);
            if (mod.ItemsUrl != null) content += $"Items Url: {mod.ItemsUrl}\n";
            if (mod.Items.Length != 0)
            {
                content += "<table>\n<tr>\n<th>Id</th>\n<th>Title</th>\n<th>Type</th>\n<th>Published</th>\n</tr>\n";
                foreach (var item in mod.Items)
                {
                    var itemPub = item.Published == true ? "published" : "unpublished";
                    var td = $"<tr>\n<td>{item.Id}</td>\n";
                    td += $"<td><a href=\"{item.HtmlUrl}\">{item.Title}</a></td>\n";
                    td += $"<td>{item.Type}</td>\n";
                    td += $"<td><span class=\"{itemPub}\"></span></td>\n</tr>\n";

                    content += td;
                }
                content += "</table>\n";
            }
            content += "</div>\n";
            return content;
        }

        //This function should generate an html report 
        public void transform()
        {
            string htmlHead = getHtmlHead();
            string htmlScripts = getHtmlScripts();
            string content = makeHtmlContent();
            string doc = "<!DOCTYPE html>\n<html>" + htmlHead + "\n" + content;
            // System.Console.WriteLine(doc);
            using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\output\activity02.html", false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(doc);
                writer.Flush();
            }
        }

        public void printReportType()
        {
            System.Console.WriteLine("My report type is {0}", reportType);
        }
    }
}