using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prospa.BusinessMatcher.Service.Utils;

namespace Prospa.BusinessMatcher.Service.Tests.Utils
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        [TestCategory("UnitTest")]
        public void Split_EmptyString_ReturnsEmptyArray() 
        {
            string input = string.Empty;
            var actual = input.Split(c => c == 'A');
            Assert.IsTrue(actual.Length == 0);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Split_NullString_ReturnsEmptyArray()
        {
            string input = null;
            var actual = input.Split(c => c == 'A');
            Assert.IsTrue(actual.Length == 0);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Split_StringPredicate_ReturnsStringArray()
        {
            string input = "ThisAwillAbeASplit";
            var actual = input.Split(c => c == 'A');
            Assert.IsTrue(actual.Length == 4);
        }
    }
}
