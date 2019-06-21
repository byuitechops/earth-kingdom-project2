using System;

namespace CanvasModuleGetter
{
    public class userInput
    {
        //not sure if we want to prompt user for their token, or not.
        public static string getToken(){
            Console.Write("Enter your token: ");
            string token = Console.ReadLine();
            return token;
        }

        //I imagine that this needs to be a list?
        public static void getCourses(){

        }

        public static string reportType(){
            Console.Write("Enter a report type (CSV, JSON, HTML): ");
            string type = Console.ReadLine();
            if (type != 'CSV' || type != 'JSON' || type != 'HTML'){
                Console.WriteLine("Report type not valid.");
                reportType();
            }
            else{
                return type;
            }
        }
    }

}