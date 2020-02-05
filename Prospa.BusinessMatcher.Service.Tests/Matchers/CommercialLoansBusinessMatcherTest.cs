using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prospa.BusinessMatcher.Service.Matchers;
using Prospa.BusinessMatcher.Service.Models;

namespace Prospa.BusinessMatcher.Service.Tests.Matchers
{
    [TestClass]
    public class CommercialLoansBusinessMatcherTest
    {
        private CommercialLoansBusinessMatcher target;

        [TestInitialize]
        public void Setup() 
        {
            this.target = new CommercialLoansBusinessMatcher();
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_MatchingBusinessNames_ReturnsTrue()
        {
            var input = new Business
            {
                Name = "Inc Rotomotor"
            };

            var control = new Business
            {
                Name = "Rotomotor Inc"
            };

            var actual = this.target.IsMatch(input, control);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_NonMatchingBusinessNames_ReturnsFalse()
        {
            var input = new Business
            {
                Name = "Mountain View Insurance"
            };

            var control = new Business
            {
                Name = "Mountain View Insurance"
            };

            var actual = this.target.IsMatch(input, control);
            Assert.IsFalse(actual);
        }
    }
}
