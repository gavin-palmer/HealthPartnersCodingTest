using System;
using System.Collections.Generic;
using System.Linq;
using HealthPartnersCodingTest.Interfaces;

namespace HealthPartnersCodingTest
{
    public class FizzBuzzCalculator: IFizzBuzzCalculator
    {

        private List<IFizzBuzzService> _services;
        private readonly int _counter = 100;
        public void Calculate()
        {
            _services = GetServices();

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

        public void PrintValue(int i, string value)
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

        public List<IFizzBuzzService> GetServices()
        {
            var serviceTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IFizzBuzzService))).ToList();

            var services = serviceTypes.Select(type => (IFizzBuzzService)Activator.CreateInstance(type)).OrderByDescending(x => x.GetType().Name).ToList();

            return services;

        }
    }
}
