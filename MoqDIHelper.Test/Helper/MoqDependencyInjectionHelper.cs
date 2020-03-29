using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnitTestMockHelper.Service.Abstraction;

namespace UnitTestMockHelper.Test.Helper
{
    /// <summary>
    /// This class created for manage DI for Moq. It has many helper methods for DI.
    /// </summary>
    public static class MoqDependencyInjectionHelper
    {
        private static readonly Type MockType = typeof(Mock<>);
        private static bool _isInitialized;
        private static readonly List<dynamic> Services = new List<dynamic>();
        private static readonly List<string> NotIncludedServices = new List<string>
        {
            nameof(IDummyService)
        };

        /// <summary>
        /// Initalize Mock services for type of <typeparamref name="T" />.
        /// </summary>
        ///<typeparam name="T">The service class type which is in test</typeparam>
        public static void InitializeAll<T>() where T : class
        {
            var parameterTypes = typeof(T)
                .GetConstructors()[0]
                .GetParameters()
                .Select(x => x.ParameterType)
                .Where(x => !NotIncludedServices.Contains(x.Name))
                .ToArray();

            if (_isInitialized)
                return;

            var createMethod = typeof(MoqDependencyInjectionHelper)
                .GetMethod(nameof(Create), BindingFlags.Public | BindingFlags.Static);

            foreach (var type in parameterTypes)
            {
                var genericMethod = createMethod?.MakeGenericMethod(type);
                genericMethod?.Invoke(null, new[] { Type.Missing });
            }

            _isInitialized = true;
        }

        /// <summary>
        /// Create <typeparamref name="T" /> type as a Mock service and return this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="behavior"></param>
        public static Mock<T> Create<T>(MockBehavior behavior = MockBehavior.Strict) where T : class
        {
            var service = Get<T>();

            if (service != null)
            {
                return service;
            }

            var mockedType = MakeGenericMockedType<T>();

            var mockInstance = (Mock<T>)Activator.CreateInstance(mockedType, behavior);

            Services.Add(mockInstance);

            return mockInstance;
        }

        /// <summary>
        /// Return the service in Mock services list which type is given as a generic parameter.
        /// </summary>
        /// <typeparam name="T">Generic type parameter</typeparam>
        public static Mock<T> Get<T>() where T : class
        {
            var mockedType = MakeGenericMockedType<T>();

            var service = Services.FirstOrDefault(x => x.GetType() == mockedType);

            return service;
        }

        /// <summary>
        /// Return all Mock service as a list.
        /// </summary>
        public static List<dynamic> GetList()
        {
            return Services.ToList();
        }

        /// <summary>
        /// Dispose specific service instance in Mock services list.
        /// </summary>
        /// <typeparam name="T">Which type to be disposed</typeparam>
        public static void Dispose<T>() where T : class
        {
            var mockedType = MakeGenericMockedType<T>();

            var service = Services.FirstOrDefault(x => x.GetType() == mockedType);

            if (service != null)
            {
                Services.Remove(service);
            }
        }

        /// <summary>
        /// Dispose all service instances in Mock services list.
        /// </summary>
        public static void DisposeAll()
        {
            Services.RemoveRange(0, Services.Count);

            // Initialize status update.
            _isInitialized = false;
        }

        #region Private

        /// <summary>
        /// Call Mock Type MakeGenericType method for T type.
        /// </summary>
        /// <typeparam name="T">The T type is which Mock generic type make you want.</typeparam>
        /// <returns></returns>
        private static Type MakeGenericMockedType<T>() where T : class
        {
            var type = typeof(T);
            var mockedType = MockType.MakeGenericType(type);

            return mockedType;
        }

        #endregion
    }
}