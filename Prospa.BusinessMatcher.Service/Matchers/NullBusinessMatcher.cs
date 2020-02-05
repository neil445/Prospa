namespace Prospa.BusinessMatcher.Service.Matchers
{
    using System;
    using Prospa.BusinessMatcher.Service.Models;

    internal class NullBusinessMatcher : IBusinessMatcher
    {
        public bool IsMatch(Business business, Business databaseBusiness)
        {
            // we can do logging here if we want,
            // or you can also just throw an exception here.
            throw new ArgumentException("Invalid partner id.");
        }
    }
}
