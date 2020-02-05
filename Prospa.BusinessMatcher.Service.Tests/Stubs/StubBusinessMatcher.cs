using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prospa.BusinessMatcher.Service.Matchers;
using Prospa.BusinessMatcher.Service.Models;

namespace Prospa.BusinessMatcher.Service.Tests.Stubs
{
    class StubBusinessMatcher : IBusinessMatcher
    {
        public bool MockResult = false;

        public bool IsMatch(Business business, Business databaseBusiness)
        {
            return this.MockResult;
        }
    }
}
