namespace Prospa.BusinessMatcher.Service.Matchers
{
    using Prospa.BusinessMatcher.Service.Models;

    public interface IBusinessMatcher
    {
        bool IsMatch(Business business, Business databaseBusiness);
    }
}
