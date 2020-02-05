namespace Prospa.BusinessMatcher.Service.Tests.Factories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Prospa.BusinessMatcher.Service.Factories;
    using Prospa.BusinessMatcher.Service.Matchers;

    [TestClass]
    public class SingletonBusinessMatcherFactoryTest
    {
        private SingletonBusinessMatcherFactory target;

        [TestInitialize]
        public void Setup() 
        {
            this.target = SingletonBusinessMatcherFactory.GetOrCreateInstance();
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void GetMatcher_InputStringLF_ReturnsLoanFacilitarotBusinessMatcher()
        {
            var input = "LF";
            var actual = this.target.GetMatcher(input);
            Assert.IsInstanceOfType(actual, typeof(LoanFacilitatorBusinessMatcher));
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void GetMatcher_InputStringELF_ReturnsEasyLoanFinderBusinessMatcher()
        {
            var input = "ELF";
            var actual = this.target.GetMatcher(input);
            Assert.IsInstanceOfType(actual, typeof(EasyLoanFinderBusinessMatcher));
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void GetMatcher_InputStringCL_ReturnsCommercialLoansBusinessMatcher()
        {
            var input = "CL";
            var actual = this.target.GetMatcher(input);
            Assert.IsInstanceOfType(actual, typeof(CommercialLoansBusinessMatcher));
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void GetMatcher_InputStringHasNoMatch_ReturnsNullBusinessMatcher()
        {
            var input = "I DONT HAVE A MATCH";
            var actual = this.target.GetMatcher(input);
            Assert.IsInstanceOfType(actual, typeof(NullBusinessMatcher));
        }
    }
}
