namespace Prospa.BusinessMatcher.Service.Factories
{
    using Prospa.BusinessMatcher.Service.Matchers;

    public interface IBusinessMatcherFactory
    {
        IBusinessMatcher GetMatcher(string partnerId);
    }
}