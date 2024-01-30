using System;
using System.Collections.Generic;
using System.Linq;
using HealthPartnersCodingTest.Interfaces;

namespace HealthPartnersCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IFizzBuzzService))).ToList();

            var services = serviceTypes.Select(type => (IFizzBuzzService)Activator.CreateInstance(type)).ToList();

            for (var i = 1; i <= 100; i++)
            {
                var value = string.Empty;
                foreach (var service in services)
                {
                    if (service.IsValid(i))
                    {
                        value = value + service.GetStringValue();
                    }
                }
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(value);
                }
            }

        }
    }
}