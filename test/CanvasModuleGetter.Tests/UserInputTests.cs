using System;
using System.Collections.Generic;
using Xunit;

namespace CanvasModuleGetter.Tests
{
    public class userInputTest
    {
        [Fact]
        public void constructorsTest()
        {
            //test default constructor
            UserInput userInput = new UserInput();

            Assert.Equal("", userInput.getReportType());
            Assert.Equal("", userInput.getToken());
            Assert.Equal(0, userInput.getCourseIds().Count);

            //test non-default constructor
            List<string> courses = new List<string>()
            {
                "10", "20"
            };
            string reportType = "JSON";
            UserInput userInput1 = new UserInput(courses, reportType);

            Assert.Equal("JSON", userInput1.getReportType());
            Assert.Equal(System.Environment.GetEnvironmentVariable("CANVAS_API_TOKEN"), userInput1.getToken());
            Assert.Equal(2, userInput1.getCourseIds().Count);
            Assert.Equal("10", userInput1.getCourseIds()[0]);
            Assert.Equal("20", userInput1.getCourseIds()[1]);
        }

        [Fact]
        public void tokenTest()
        {
            UserInput userInput = new UserInput();
            Assert.Equal("", userInput.getToken());
        }

        [Fact]
        public void courseIdTest()
        {
            List<string> courses = new List<string>()
            {
                "80", "90"
            };
            string reportType = "JSON";

            UserInput userInput = new UserInput(courses, reportType);

            Assert.Equal("80", userInput.getCourseIds()[0]);
            Assert.Equal("90", userInput.getCourseIds()[1]);
        }

        [Fact]
        public void reportTypeTest()
        {
            List<string> courses = new List<string>()
            {
                "80"
            };
            string reportType = "JSON";

            UserInput userInput = new UserInput(courses, reportType);

            Assert.Equal("JSON", userInput.getReportType());
        }
    }
}
