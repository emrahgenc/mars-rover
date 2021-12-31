using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Application.Tests.Demo
{
    public class _3_SettingUpTearDown: IDisposable, IAsyncLifetime
    {
        private readonly Stack<int> stack;

        public _3_SettingUpTearDown()
        {
            //Isolation !!
            stack = new Stack<int>();
        }
        public void Dispose()
        {
            stack.Clear();
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask; 
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        ~_3_SettingUpTearDown()
        {
            
        }
        
        [Fact]
        public void Test1()
        {
            var count = stack.Count;

            Assert.Equal(0, count);
        }

        [Fact]
        public void Test2()
        {
            stack.Push(42);

            var count = stack.Count;

            Assert.Equal(1, count);
        }
        
        [Fact]
        public void Test3()
        {
            stack.Push(42);
            stack.Push(42);
            stack.Push(42);
            
            var count = stack.Count;

            Assert.Equal(3, count);
        }
    }
}