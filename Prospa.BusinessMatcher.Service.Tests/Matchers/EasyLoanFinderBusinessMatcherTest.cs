using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prospa.BusinessMatcher.Service.Matchers;
using Prospa.BusinessMatcher.Service.Models;

namespace Prospa.BusinessMatcher.Service.Tests.Matchers
{
    [TestClass]
    public class EasyLoanFinderBusinessMatcherTest
    {
        private EasyLoanFinderBusinessMatcher target;

        [TestInitialize]
        public void Setup() 
        {
            this.target = new EasyLoanFinderBusinessMatcher();
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_BusinessCoordinatesWithin200Meters_ReturnsTrue()
        {
            var input = new Business
            {
                Latitude = 14.5617339m,
                Longitude = 121.015123m
            };

            var control = new Business
            {
                Latitude = 14.561430m,
                Longitude = 121.015915m
            };

            var actual = this.target.IsMatch(input, control);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_BusinessCoordinatesOutOf200Meters_ReturnsFalse()
        {
            var input = new Business
            {
                Latitude = 14.5617339m,
                Longitude = 121.015123m
            };

            var control = new Business
            {
                Latitude = 14.566127m,
                Longitude = 121.023064m
            };

            var actual = this.target.IsMatch(input, control);
            Assert.IsFalse(actual);
        }
    }
}
