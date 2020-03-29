using System;
using UnitTestMockHelper.Service.Abstraction;

namespace UnitTestMockHelper.Service.Concrete
{
    public class DummyAnotherService : IDummyAnotherService
    {
        public bool DummyAnother(int dummyInt)
        {
            if (dummyInt % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}