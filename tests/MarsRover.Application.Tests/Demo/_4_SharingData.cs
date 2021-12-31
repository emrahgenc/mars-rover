using System;
using System.Diagnostics;
using Xunit;

namespace MarsRover.Application.Tests.Demo
{
    public class _4_SharingData: IClassFixture<SharedObject>
    {
        private readonly SharedObject _sharedObject;

        public _4_SharingData(SharedObject sharedObject)
        {
            _sharedObject = sharedObject;
        }

        [Fact]
        public void _2_plus_2_eq_4()
        {
            Debugger.Log(1, "test", _sharedObject.Date.ToString());
            Assert.Equal(4, _sharedObject.Sum(2, 2));
        }
        
        [Fact]
        public void _1_plus_2_eq_3()
        {
            Debugger.Log(1, "test", _sharedObject.Date.ToString());
            Assert.Equal(4, _sharedObject.Sum(2, 2));
        }
    }

    public class SharedObject
    {
        public SharedObject()
        {
            Date = DateTime.Now.Ticks;
        }

        public long Date { get; set; }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}