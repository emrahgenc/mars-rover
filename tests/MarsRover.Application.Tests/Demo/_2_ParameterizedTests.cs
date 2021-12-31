using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace MarsRover.Application.Tests.Demo
{
    public class ParameterizedTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 1, 2)]
        [InlineData(1, 3, 4)]
        public void Test1(int a, int b, int expected)
        {
            var actual = Sum(a, b);
            Assert.Equal(expected, actual);
        }

        private int Sum(int a, int b)
        {
            return a + b;
        }
        
        [Theory]           
        [MemberData(nameof(Test2Data))]   
        public void Test2(int a, int b, int expected)
        {
            var actual = Sum(a, b);
            Assert.Equal(expected, actual);
        }
        
        public static IEnumerable<object[]> Test2Data()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 1, 1, 2 };
        }
       
        
        
        [Theory] 
        [ClassData(typeof(Test3DataClass))]
        public void Test3(int a, int b, int expected)
        {
            Assert.Equal(expected, a + b);
        }
        
        
        [Theory] 
        [Test4Data]
        public void Test4(int a, int b, int expected)
        {
            Assert.Equal(expected, a + b);
        }
    }
    
    public class Test3DataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 1, 1, 2 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class Test4DataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 1, 1, 2 };
        }
    }
}