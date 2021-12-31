using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Application.Tests.Demo
{
    public class ExploringAsserts
    {
        [Fact]
        public void LearningAssertions()
        {
            int? expected = 5;
            int result = 5;
            
            Assert.Equal(expected, result);

            Assert.NotNull(expected);
            Assert.False(false);
            
            var a = new A();
            
            int metdosResult = 0;
            Action act = () => { metdosResult= a.Test(); };

            Assert.Throws<Exception>(act);
            Assert.Equal(0, metdosResult);

//Single
//Exception
        }

        public class A
        {
            public int Test()
            {
                throw new WarningException();
            }
        }
    }
}