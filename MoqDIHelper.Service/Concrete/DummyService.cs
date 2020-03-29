using UnitTestMockHelper.Service.Abstraction;

namespace UnitTestMockHelper.Service.Concrete
{
    public class DummyService : IDummyService
    {
        public long Divide(int a, int b)
        {
            return a / b;
        }

        public long Minus(long a, long b)
        {
            return a + b;
        }

        public long Multiply(int a, int b)
        {
            return a * b;
        }

        public long Plus(long a, long b)
        {
            return a + b;
        }
    }
}