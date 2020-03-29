using System;
using UnitTestMockHelper.Test.Helper;

namespace UnitTestMockHelper.Test.Base
{
    /// <summary>
    /// Test Base class. This class includes useful methods and properties.
    /// </summary>
    public abstract class TestBase<T> : IDisposable where T : class
    {
        protected T ServiceInstance { get; set; }

        protected TestBase()
        {
            //Mock services initialize
            MoqDependencyInjectionHelper.InitializeAll<T>();
        }

        public void Dispose()
        {
            MoqDependencyInjectionHelper.DisposeAll();
        }
    }
}