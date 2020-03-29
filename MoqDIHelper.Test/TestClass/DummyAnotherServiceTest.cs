using NUnit.Framework;
using UnitTestMockHelper.Service.Concrete;
using UnitTestMockHelper.Test.Base;

namespace UnitTestMockHelper.Test.TestClass
{
    public class DummyAnotherServiceTest : TestBase<DummyAnotherService>
    {
        [OneTimeSetUp]
        public void Setup()
        {
            ServiceInstance = new DummyAnotherService();
        }
        
        #region DummyAnother

        [Test]
        public void DummyAnother_WrongInt_StatusFalse()
        {
            var result = ServiceInstance.DummyAnother(9);

            Assert.IsFalse(result);
        }

        [Test]
        public void DummyAnother_CorrectInt_StatusTrue()
        {
            var result = ServiceInstance.DummyAnother(4);

            Assert.IsTrue(result);
        }

        #endregion
    }
}