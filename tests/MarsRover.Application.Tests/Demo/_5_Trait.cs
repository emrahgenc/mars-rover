using Xunit;

namespace MarsRover.Application.Tests.Demo
{
    [Trait("Area", "API")]
    public class _5_Trait
    {
        [Fact]
        [Trait("Category", "Integration")]
        [Trait("Issue", "123")]
        public void Test()
        {
            Assert.Equal(4, 2 + 2);
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void Test1()
        {
            Assert.Equal(4, 2 + 2);
        }
    }
}