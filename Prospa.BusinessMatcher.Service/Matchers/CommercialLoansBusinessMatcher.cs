namespace Prospa.BusinessMatcher.Service.Matchers
{
    using System;
    using System.Linq;
    using Prospa.BusinessMatcher.Service.Models;

    internal class CommercialLoansBusinessMatcher : IBusinessMatcher
    {
        public bool IsMatch(Business business, Business databaseBusiness)
        {
            var businessName = string.Join(" ", business.Name.Split(' ').Reverse());
            var databaseBusinessName = string.Join(" ", databaseBusiness.Name.Split(' '));

            bool result = businessName.Equals(databaseBusinessName, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }
    }
}
