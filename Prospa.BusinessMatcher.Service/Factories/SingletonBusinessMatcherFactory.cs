namespace Prospa.BusinessMatcher.Service.Factories
{
    using System;
    using System.Collections.Generic;
    using Prospa.BusinessMatcher.Service.Matchers;

    /// <summary>
    /// Singleton class that gives out the proper matching strategy for the input.
    /// </summary>
    /// <remarks>Returns the default NullBusinessMatcher class object if the input has no corresponding matcher.</remarks>
    public class SingletonBusinessMatcherFactory : IBusinessMatcherFactory
    {
        private static SingletonBusinessMatcherFactory instance;

        private static Dictionary<string, Func<IBusinessMatcher>> matchers;

        private SingletonBusinessMatcherFactory()
        {
            matchers = new Dictionary<string, Func<IBusinessMatcher>>
            {
                { "LF",  () => { return new LoanFacilitatorBusinessMatcher(); } },
                { "ELF", () => { return new EasyLoanFinderBusinessMatcher(); } },
                { "CL", () => { return new CommercialLoansBusinessMatcher(); } }
            };
        }

        public static SingletonBusinessMatcherFactory GetOrCreateInstance()
        {
            if (instance == null)
            {
                instance = new SingletonBusinessMatcherFactory();
            }

            return instance;
        }

        public IBusinessMatcher GetMatcher(string partnerId)
        {
            // set default matcher if any, or;
            // implement null-object pattern.
            IBusinessMatcher result = new NullBusinessMatcher();

            Func<IBusinessMatcher> matcher = null;
            if (matchers.TryGetValue(partnerId.ToUpper().Trim(), out matcher)) 
            {
                result = matcher();
            }

            return result;
        }
    }
}
