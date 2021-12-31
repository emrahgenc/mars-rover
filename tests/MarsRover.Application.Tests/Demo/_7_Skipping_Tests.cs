using Xunit;

namespace MarsRover.Application.Tests.Demo
{
    public class _7_Skipping_Tests
    {
        [Fact(Skip = "This test is disabled")]
        public void Test1()
        {
        }
        
        [Fact(DisplayName = "İki rakamın toplamı doğru geldiği test")]
        public void Test_that_1_plus_1_eq_2()
        {
            Assert.Equal(2, 1 + 1);
        }
    }
}   