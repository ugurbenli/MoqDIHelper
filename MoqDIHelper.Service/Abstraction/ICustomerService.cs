using UnitTestMockHelper.Service.Entity;
using UnitTestMockHelper.Service.Model;

namespace UnitTestMockHelper.Service.Abstraction
{
    public interface ICustomerService
    {
        CustomerServiceResponse AddCustomer(Customer entity);

        CustomerServiceResponse GetCustomer(string id);

        CustomerServiceResponse DeleteCustomer(string id);

        CustomerServiceResponse UpdateCustomer(Customer entity);
    }
}