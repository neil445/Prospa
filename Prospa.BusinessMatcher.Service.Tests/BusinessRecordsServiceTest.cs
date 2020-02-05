using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prospa.BusinessMatcher.Service.Models;
using Prospa.BusinessMatcher.Service.Tests.Stubs;

namespace Prospa.BusinessMatcher.Service.Tests
{
    [TestClass]
    public class BusinessRecordsServiceTest
    {
        private StubBusinessMatcherFactory stubBusinessMatcherFactory;
        private StubBusinessDataRepository stubRepository;
        private BusinessRecordsService target;

        [TestInitialize]
        public void Setup() 
        {
            this.stubBusinessMatcherFactory = new StubBusinessMatcherFactory();
            this.stubRepository = new StubBusinessDataRepository();
            this.target = new BusinessRecordsService(this.stubBusinessMatcherFactory, this.stubRepository);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void CreateOrUpdateBusinessRecordAsync_BusinessRecordsDoesNotExists_InsertExecuted()
        {
            var mockInput = new Business() 
            {
                PartnerId = "LF"
            };

            this.stubBusinessMatcherFactory.MockBusinessMatcher.MockResult = false;
            this.target.CreateOrUpdateBusinessRecordAsync(mockInput).Wait();
            Assert.IsTrue(this.stubRepository.InsertFlag);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void CreateOrUpdateBusinessRecordAsync_BusinessRecordsExists_UpdateExecuted()
        {
            var mockInput = new Business()
            {
                PartnerId = "LF"
            };

            this.stubBusinessMatcherFactory.MockBusinessMatcher.MockResult = true;
            this.target.CreateOrUpdateBusinessRecordAsync(mockInput).Wait();
            Assert.IsTrue(this.stubRepository.UpdateFlag);
        }
    }
}
