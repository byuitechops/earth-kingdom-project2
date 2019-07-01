using System;
using System.Collections.Generic;
using System.IO;

namespace CanvasModuleGetter
{
    public class HtmlReport : IReportTransform
    {
        private List<string> courses { get; }
        private string reportType { get; }


        public HtmlReport(List<string> courses)
        {
            this.courses = courses;
            reportType = "HTML";
        }

        public string getHtmlHead()
        {
            string textFile = "./HtmlFiles/head.html";
            string headText = File.ReadAllText(textFile);  
            Console.WriteLine(headText);  
            return headText;
        }

        public string getHtmlScripts()
        {
            string textFile = "./HtmlFiles/scripts.html";
            string scriptsText = File.ReadAllText(textFile);  
            Console.WriteLine(scriptsText);  
            return scriptsText;
        }

        public string makeHtmlContent()
        {
            var content = "";
            

            return content;
        }

        //This function should generate an html report 
        public void transform()
        {
            string htmlHead = getHtmlHead();
            string htmlScripts = getHtmlScripts();
            string content = makeHtmlContent();            

        }

        public void printReportType()
        {
            System.Console.WriteLine("My report type is {0}", reportType);
        }
    }
}