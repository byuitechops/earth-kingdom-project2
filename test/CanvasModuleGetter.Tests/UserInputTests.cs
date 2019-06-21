using System;
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
            UserInput up = new UserInput("132", "C");
            Assert.Equal("132", up.getCourseId());
        }

        //[Fact]
        public void reportTypeTest()
        {
            UserInput up = new UserInput("140", "CSV");
            Assert.Equal("CSV", up.getReportType());
        }
    }
}
