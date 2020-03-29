namespace UnitTestMockHelper.Service.Abstraction
{
    public interface IDummyService
    {
        long Plus(long a, long b);

        long Minus(long a, long b);

        long Multiply(int a, int b);

        long Divide(int a, int b);
    }
}