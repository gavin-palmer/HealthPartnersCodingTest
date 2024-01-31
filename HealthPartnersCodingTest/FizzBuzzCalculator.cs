using System;
using System.Collections.Generic;
using System.Linq;
using HealthPartnersCodingTest.Interfaces;

namespace HealthPartnersCodingTest
{
    public class FizzBuzzCalculator: IFizzBuzzCalculator
    {
        public FizzBuzzCalculator() { }
        // for unit tests
        public FizzBuzzCalculator(int counter, List<IFizzBuzzService> services)
        {
            _counter = counter;
            _services = services;
        }

        private List<IFizzBuzzService> _services;
        private readonly int _counter = 100;
        public void Calculate()
        {
             GetServices();

            for (var i = 1; i <= _counter; i++)
            {
                ProcessValue(i);
            }
        }

        public void ProcessValue(int i)
        {
            var value = string.Empty;
            foreach (var service in _services)
            {
                if (service.IsValid(i))
                {
                    value = value + service.GetStringValue();
                }
            }

            PrintValue(i, value);
        }

        private void PrintValue(int i, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine(i);
            }
            else
            {
                Console.WriteLine(value);
            }
        }

        private void GetServices()
        {
            if (_services == null)
            {
                var serviceTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IFizzBuzzService))).ToList();

                _services = serviceTypes.Select(type => (IFizzBuzzService)Activator.CreateInstance(type)).OrderByDescending(x => x.GetType().Name).ToList();
            }
        }
    }
}
