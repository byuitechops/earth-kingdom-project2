using System;
using Xunit;

namespace CanvasModuleGetter.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = 5;
            var y = 6;

            var result = x * y;

            Assert.Equal(31, result);
        }
    }
}
