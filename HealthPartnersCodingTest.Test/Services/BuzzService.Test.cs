using System;
using Xunit;
using HealthPartnersCodingTest.Services;


namespace HealthPartnersCodingTest.Test.Services
{
    public class BuzzServiceTest
    {

        [Fact]
        public void IsBuzz()
        {
            // arrange
            var buzzService = new BuzzService();
            // act
            var buzz = buzzService.GetStringValue();
            //assert
            Assert.Equal("Buzz", buzz);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        public void IsValidBuzz(int n)
        {
            // arrange
            var buzzService = new BuzzService();
            // act
            var isValid = buzzService.IsValid(n);
            //assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void IsInvalidBuzz(int n)
        {
            // arrange
            var buzzService = new BuzzService();
            // act
            var isValid = buzzService.IsValid(n);
            //assert
            Assert.False(isValid);
        }
    }
}
