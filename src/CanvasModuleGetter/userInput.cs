using System;

namespace CanvasModuleGetter
{
    public class UserInput
    {
        private string courseId;
        private string reportType;


        public UserInput()
        {
            this.courseId = "";
            this.reportType = "";
        }
        public UserInput(string courseId, string reportType)
        {
            this.courseId = courseId;
            this.reportType = reportType;
        }

        //not sure if we want to prompt user for their token, or not.
        //Evgeniy: I feel like we don't need this. The user won't be enetring that huge string into the program. 
        public static string getToken()
        {
            Console.Write("Enter your token: ");
            string token = Console.ReadLine();
            return token;
        }

        //I imagine that this needs to be a list?
        //Evgeniy: Does this need to be in this Class? 
        public static void getCourses()
        {

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