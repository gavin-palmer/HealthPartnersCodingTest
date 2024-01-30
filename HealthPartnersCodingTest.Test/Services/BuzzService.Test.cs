using System;
using Xunit;

namespace HealthPartnersCodingTest.Test.Services
{
    public class BuzzService
    {
        [Fact]
        public void IsBuzz()
        {
             
        }

        [Theory]
        [InlineData(3)]
        public void IsValidBuzz(int n)
        {

        }

        [Theory]
        [InlineData(3)]
        public void IsInvalidBuzz(int n)
        {

        }
    }
}
