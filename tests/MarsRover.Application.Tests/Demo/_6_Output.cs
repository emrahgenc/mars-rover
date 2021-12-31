using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace MarsRover.Application.Tests.Demo
{
    public class _6_Output
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public _6_Output(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void Test1()
        {
            _testOutputHelper.WriteLine("This is a log from the test output helper");
            Debugger.Log(1, "test", "This is a log from the debugger");
            Assert.Equal(4, 5);
        }
    }
}