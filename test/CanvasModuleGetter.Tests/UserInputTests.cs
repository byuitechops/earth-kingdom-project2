using System;
using System.Collections.Generic;
using Xunit;

namespace CanvasModuleGetter.Tests
{
    public class userInputTest
    {
        [Fact]
        public void tokenTest()
        {

        }

        [Fact]
        public void courseIdTest()
        {
            List<string> courses = new List<string>()
            {
                "80", "80"
            };
            string reportType = "JSON";

            UserInput userInput = new UserInput(courses, reportType);

            Assert.Equal("80", userInput.getCourseIds()[0]);
            Assert.Equal("80", userInput.getCourseIds()[1]);
        }

        //[Fact]
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
