using System;
using System.Collections.Generic;

namespace CanvasModuleGetter
{
    public class UserInput
    {
        private List<string> courseIds;
        private string reportType;
        private string token;
        private List<string> courses;

        public UserInput()
        {
            this.courseIds = new List<string>();
            this.reportType = "";
            this.token = "";
            this.courses = new List<string>();
        }

        public string getToken()
        {
            return token;
        }

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

        public List<string> getCourseIds()
        {
            return courseIds;
        }
        public string getReportType()
        {
            return reportType;
        }

        //This function prompt the user for a course ID and the type of report file.
        public void promptUser()
        {
            token = System.Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");

            string courseId = "-1";
            Console.WriteLine("Enter course IDs. To stop enter 0");
            while (courseId != "0")
            {
                courseId = Console.ReadLine();
                if (courseId != "0")
                {
                    courseIds.Add(courseId);
                }
            }

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