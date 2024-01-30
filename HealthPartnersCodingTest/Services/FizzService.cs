using System;
using HealthPartnersCodingTest.Interfaces;

namespace HealthPartnersCodingTest.Services
{
    public class FizzService : IFizzBuzzService
    {
        public string GetStringValue()
        {
            return "Fizz";
        }

        public bool IsValid(int number)
        {
            return number % 3 == 0;
        }
    }
}
