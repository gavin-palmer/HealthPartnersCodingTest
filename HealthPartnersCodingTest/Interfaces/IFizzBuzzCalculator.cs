using System;
using System.Collections.Generic;

namespace HealthPartnersCodingTest.Interfaces
{
    public interface IFizzBuzzCalculator
    {
        void Calculate();
        void ProcessValue(int i);
        void PrintValue(int i, string value);
        List<IFizzBuzzService> GetServices();
    }
}
