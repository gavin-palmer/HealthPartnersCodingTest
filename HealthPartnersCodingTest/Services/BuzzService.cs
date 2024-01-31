using System;
using HealthPartnersCodingTest.Interfaces;

namespace HealthPartnersCodingTest.Services
{
    public class BuzzService: IFizzBuzzService
    {
        public string GetStringValue()
        {
            return "Buzz";
        }

        public bool IsValid(int number)
        {
            return number % 5 == 0;
        }
    }
}
