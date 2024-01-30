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
            var calculator = new FizzBuzzCalculator();

            calculator.Calculate();

        }
    }
}