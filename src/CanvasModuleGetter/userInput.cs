using System;
using System.Collections.Generic;

namespace CanvasModuleGetter
{
    public class UserInput
    {
        private string courseId;
        private string reportType;
        private string token;
        private List<string> courses;

        public UserInput()
        {
            this.courseId = "";
            this.reportType = "";
            this.token = "";
            this.courses = new List<string>();
        }
        public UserInput(string courseId, string reportType)
        {
            this.courseId = courseId;
            this.reportType = reportType;
        }

        public string getToken()
        {
            return token;
        }

        //I imagine that this needs to be a list?
        //Evgeniy: Does this need to be in this Class? 
        //Seth: Yes.
        public static void getCourseList()
        {
            List<string> courseList = new List<string>();
            string path = "";
            while (path != "")
            {
                Console.Write("Enter the path to your course list CSV: ");
                path = Console.ReadLine();
            }

        }

        public string getCourseId()
        {
            return courseId;
        }
        public string getReportType()
        {
            return reportType;
        }

        //This function prompt the user for a course ID and the type of report file.
        public void promptUser()
        {
            token = System.Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");
            Console.Write("Enter course ID: ");
            courseId = Console.ReadLine();

            string type = "";
            while (type != "CSV" && type != "JSON" && type != "HTML")
            {
                Console.Write("Enter a report type (CSV, JSON, HTML): ");
                type = Console.ReadLine().ToUpper();
            }

            reportType = type;
        }
    }
}