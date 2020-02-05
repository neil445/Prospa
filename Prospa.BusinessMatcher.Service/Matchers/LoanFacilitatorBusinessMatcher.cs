namespace Prospa.BusinessMatcher.Service.Matchers
{
    using System;
    using Prospa.BusinessMatcher.Service.Models;
    using Prospa.BusinessMatcher.Service.Utils;

    internal class LoanFacilitatorBusinessMatcher : IBusinessMatcher
    {
        public bool IsMatch(Business business, Business databaseBusiness)
        {
            string businessName = SplitAndJoin(business.Name);
            string address = SplitAndJoin(business.Address);
            string databaseBusinessName = SplitAndJoin(databaseBusiness.Name);
            string databaseAddress = SplitAndJoin(databaseBusiness.Address);

            bool result = businessName.Equals(databaseBusinessName, StringComparison.InvariantCultureIgnoreCase) 
                && address.Equals(databaseAddress, StringComparison.InvariantCultureIgnoreCase);

            return result;
        }

        private static string SplitAndJoin(string str)
        {
            return string.Join(" ", str.Split(c => !char.IsLetterOrDigit(c)));
        }
    }
}
