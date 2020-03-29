using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestMockHelper.Service.Abstraction;
using UnitTestMockHelper.Service.Entity;
using UnitTestMockHelper.Service.Model;

namespace UnitTestMockHelper.Service.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IDummyService _dummyService;
        private readonly IDummyAnotherService _dummyServiceAnother;
        private static readonly List<Customer> _customerList;

        static CustomerService()
        {
            _customerList = new List<Customer>();
        }

        public CustomerService(IDummyService dummyService, IDummyAnotherService dummyServiceAnother)
        {
            _dummyService = dummyService;
            _dummyServiceAnother = dummyServiceAnother;
        }

        public CustomerServiceResponse AddCustomer(Customer entity)
        {
            if (entity == null)
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = "Customer entity cannot be null"
                };

            if (string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrWhiteSpace(entity.LastName))
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = $"{nameof(entity.FirstName)} or " +
                    $"{nameof(entity.LastName)} cannot be null or empty"
                };

            entity.Id = Guid.NewGuid().ToString();

            _customerList.Add(entity);

            return new CustomerServiceResponse
            {
                Status = true,
                Message = "Customer added",
                Customer = entity
            };
        }

        public CustomerServiceResponse DeleteCustomer(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = "Id cannot be null or empty"
                };

            var customer = _customerList.FirstOrDefault(x => x.Id == id);

            if (customer == null)
                return new CustomerServiceResponse { Status = false, Message = "Customer not found" };

            if (_dummyServiceAnother.DummyAnother(5))
            {
                _customerList.Remove(customer);

                return new CustomerServiceResponse { Status = true, Message = "Customer deleted" };
            }

            return new CustomerServiceResponse { Status = false };
        }

        public CustomerServiceResponse GetCustomer(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                return new CustomerServiceResponse { Status = false, Message = "Id cannot be null or empty" };

            var customer = _customerList.FirstOrDefault(x => x.Id == id);

            if (customer == null)
                return new CustomerServiceResponse { Status = false, Message = "Customer not found" };

            return new CustomerServiceResponse
            {
                Status = true,
                Customer = customer
            };
        }

        public CustomerServiceResponse UpdateCustomer(Customer updateModel)
        {
            if (updateModel == null)
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = $"Customer entity cannot be null"
                };

            if (string.IsNullOrEmpty(updateModel.Id) || string.IsNullOrWhiteSpace(updateModel.Id))
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = "Id cannot be null or empty"
                };

            var customer = _customerList.FirstOrDefault(x => x.Id == updateModel.Id);

            if (customer == null)
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = $"Customer not found"
                };

            if (string.IsNullOrEmpty(updateModel.FirstName) || string.IsNullOrWhiteSpace(updateModel.LastName))
                return new CustomerServiceResponse
                {
                    Status = false,
                    Message = "FirstName or LastName cannot be null or empty"
                };

            customer.FirstName = updateModel.FirstName;
            customer.LastName = updateModel.LastName;

            return new CustomerServiceResponse
            {
                Status = true,
                Message = "Customer updated",
                Customer = customer
            };
        }
    
    }
}