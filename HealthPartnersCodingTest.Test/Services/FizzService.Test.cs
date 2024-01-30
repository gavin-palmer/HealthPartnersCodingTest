using System;
using Xunit;

namespace HealthPartnersCodingTest.Test.Services
{
    public class FizzService
    {
        [Fact]
        public void IsFizz()
        {

        }

        [Theory]
        [InlineData(3)]
        public void IsValidFizz(int n)
        {

        }

        [Theory]
        [InlineData(3)]
        public void IsInvalidFizz(int n)
        {

        }
    }
}
