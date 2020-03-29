using Moq;
using NUnit.Framework;
using System;
using UnitTestMockHelper.Service.Abstraction;
using UnitTestMockHelper.Service.Concrete;
using UnitTestMockHelper.Service.Entity;
using UnitTestMockHelper.Service.Model;
using UnitTestMockHelper.Test.Base;
using UnitTestMockHelper.Test.Helper;

namespace UnitTestMockHelper.Test.TestClass
{
    public class CustomerServiceTest : TestBase<CustomerService>
    {
        private Mock<IDummyAnotherService> _dummyServiceAnother;

        [OneTimeSetUp]
        public void Setup()
        {
            // DummyService came from MockServiceHelper DI list
            _dummyServiceAnother = MoqDependencyInjectionHelper.Get<IDummyAnotherService>();

            ServiceInstance = new CustomerService(new DummyService(), _dummyServiceAnother.Object);
        }

        #region AddCustomer

        [Test]
        public void AddCustomer_NullEntity_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Customer entity cannot be null"
            };

            var actualResult = ServiceInstance.AddCustomer(null);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void AddCustomer_NullFirstName_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = null,
                LastName = "Test"
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void AddCustomer_EmptyFirstName_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = string.Empty,
                LastName = "Test"
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void AddCustomer_NullLastName_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test",
                LastName = null
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void AddCustomer_EmptyLastName_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test",
                LastName = string.Empty
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void AddCustomer_CorrectResult_StatusTrue()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = true,
                Message = "Customer added"
            };

            var actualResult = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNotNull(actualResult.Customer);
        }

        #endregion

        #region DeleteCustomer

        [Test]
        public void DeleteCustomer_NullId_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Id cannot be null or empty"
            };

            var actualResult = ServiceInstance.DeleteCustomer(null);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNull(actualResult.Customer);
        }

        [Test]
        public void DeleteCustomer_EmptyId_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Id cannot be null or empty"
            };

            var actualResult = ServiceInstance.DeleteCustomer(string.Empty);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNull(actualResult.Customer);
        }

        [Test]
        public void DeleteCustomer_NullEntity_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Customer not found"
            };

            var actualResult = ServiceInstance.DeleteCustomer(Guid.NewGuid().ToString());

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNull(actualResult.Customer);
        }

        [Test]
        public void DeleteCustomer_CorrectResult_StatusTrue()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            // Dummy Mock Method Setup
            _dummyServiceAnother.Setup(x => x.DummyAnother(5))
                .Returns(true);

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = true,
                Message = "Customer deleted"
            };

            var actualResult = ServiceInstance.DeleteCustomer(customer.Customer.Id);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        #endregion

        #region GetCustomer

        [Test]
        public void GetCustomer_NullId_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Id cannot be null or empty"
            };

            var actualResult = ServiceInstance.GetCustomer(null);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNull(actualResult.Customer);
        }

        [Test]
        public void GetCustomer_EmptyId_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Id cannot be null or empty"
            };

            var actualResult = ServiceInstance.GetCustomer(string.Empty);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNull(actualResult.Customer);
        }

        [Test]
        public void GetCustomer_NullEntity_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Customer not found"
            };

            var actualResult = ServiceInstance.GetCustomer(Guid.NewGuid().ToString());

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.IsNull(actualResult.Customer);
        }

        [Test]
        public void GetCustomer_CorrectResult_StatusTrue()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = true
            };

            var actualResult = ServiceInstance.GetCustomer(customer.Customer.Id);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.IsNotNull(actualResult.Customer);
        }

        #endregion

        #region UpdateCustomer

        [Test]
        public void UpdateCustomer_NullEntity_StatusFalse()
        {
            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "Customer entity cannot be null"
            };

            var actualResult = ServiceInstance.UpdateCustomer(null);

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void UpdateCustomer_NullFirstName_StatusFalse()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.UpdateCustomer(new Customer
            {
                Id = customer.Customer.Id,
                FirstName = null,
                LastName = "Test"
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void UpdateCustomer_EmptyFirstName_StatusFalse()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.UpdateCustomer(new Customer
            {
                Id = customer.Customer.Id,
                FirstName = string.Empty,
                LastName = "Test"
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void UpdateCustomer_NullLastName_StatusFalse()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.UpdateCustomer(new Customer
            {
                Id = customer.Customer.Id,
                FirstName = "Test",
                LastName = null
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void UpdateCustomer_EmptyLastName_StatusFalse()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = false,
                Message = "FirstName or LastName cannot be null or empty"
            };

            var actualResult = ServiceInstance.UpdateCustomer(new Customer
            {
                Id = customer.Customer.Id,
                FirstName = "Test",
                LastName = string.Empty
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
        }

        [Test]
        public void UpdateCustomer_CorrectResult_StatusTrue()
        {
            #region Preperation

            var customer = ServiceInstance.AddCustomer(new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            });

            #endregion

            var expextedResult = new CustomerServiceResponse
            {
                Status = true,
                Message = "Customer updated"
            };

            var actualResult = ServiceInstance.UpdateCustomer(new Customer
            {
                Id = customer.Customer.Id,
                FirstName = "Test FirstName 2",
                LastName = "Test LastName 2"
            });

            Assert.AreEqual(expextedResult.Status, actualResult.Status);
            Assert.AreEqual(expextedResult.Message, actualResult.Message);
            Assert.AreEqual(customer.Customer.FirstName, actualResult.Customer.FirstName);
            Assert.AreEqual(customer.Customer.LastName, actualResult.Customer.LastName);
        }

        #endregion
    }
}