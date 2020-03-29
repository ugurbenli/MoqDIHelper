using UnitTestMockHelper.Service.Entity;

namespace UnitTestMockHelper.Service.Model
{
    public class CustomerServiceResponse
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public Customer Customer { get; set; }
    }
}