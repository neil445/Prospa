using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prospa.BusinessMatcher.Service.Matchers;
using Prospa.BusinessMatcher.Service.Models;

namespace Prospa.BusinessMatcher.Service.Tests.Matchers
{
    [TestClass]
    public class LoanFacilitatorBusinessMatcherTest
    {
        private LoanFacilitatorBusinessMatcher target;

        [TestInitialize]
        public void Setup() 
        {
            this.target = new LoanFacilitatorBusinessMatcher();
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_MatchingBusinesses_ReturnsTrue() 
        {
            var input = new Business
            {
                Name = "*Annie-Stones!and Steel Works",
                Address = "7_Cup_Street"
            };

            var control = new Business 
            {
                Name = "Annie Stones and Steel Works",
                Address = "7 Cup Street"
            };
            
            var actual = this.target.IsMatch(input, control);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_NonMatchingBusinessesName_ReturnsFalse()
        {
            var input = new Business
            {
                Name = "*Bernie-Stones!%and Steel Works",
                Address = "7_Cup_Street"
            };

            var control = new Business
            {
                Name = "Annie Stones and Steel Works",
                Address = "7 Cup Street"
            };

            var actual = this.target.IsMatch(input, control);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void IsMatch_NonMatchingBusinessesAddress_ReturnsFalse()
        {
            var input = new Business
            {
                Name = "*Annie-Stones!and Steel Works",
                Address = "21_Jump_Street"
            };

            var control = new Business
            {
                Name = "Annie Stones and Steel Works",
                Address = "7 Cup Street"
            };

            var actual = this.target.IsMatch(input, control);
            Assert.IsFalse(actual);
        }
    }
}
