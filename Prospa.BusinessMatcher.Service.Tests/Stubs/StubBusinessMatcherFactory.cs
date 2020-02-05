namespace Prospa.BusinessMatcher.Service.Tests.Stubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Prospa.BusinessMatcher.Service.Factories;
    using Prospa.BusinessMatcher.Service.Matchers;

    class StubBusinessMatcherFactory : IBusinessMatcherFactory
    {
        public StubBusinessMatcher MockBusinessMatcher;

        public StubBusinessMatcherFactory()
        {
            this.MockBusinessMatcher = new StubBusinessMatcher();
        }

        public IBusinessMatcher GetMatcher(string partnerId)
        {
            return this.MockBusinessMatcher;
        }
    }
}
