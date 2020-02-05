namespace Prospa.BusinessMatcher.Service
{
    using System.Linq;
    using System.Threading.Tasks;
    using Prospa.BusinessMatcher.Service.Data;
    using Prospa.BusinessMatcher.Service.Factories;
    using Prospa.BusinessMatcher.Service.Matchers;
    using Prospa.BusinessMatcher.Service.Models;

    public class BusinessRecordsService : IBusinessRecordsService
    {
        private readonly IBusinessMatcherFactory businessMatcherFactory;
        private readonly IBusinessDataRepository businessRepository;

        public BusinessRecordsService(IBusinessMatcherFactory businessMatcherFactory, IBusinessDataRepository businessRepository)
        {
            this.businessMatcherFactory = businessMatcherFactory;
            this.businessRepository = businessRepository;
        }

        public async Task<Business> CreateOrUpdateBusinessRecordAsync(Business business)
        {
            IQueryable<Business> businessRecords = await this.businessRepository.GetByPartnerId(business.PartnerId);
            IBusinessMatcher matcher = this.businessMatcherFactory.GetMatcher(business.PartnerId);

            if (businessRecords.Any(businessRecord => matcher.IsMatch(business, businessRecord)))
            {
                return await this.businessRepository.UpdateAsync(business);
            }

            return await this.businessRepository.InsertAsync(business);
        }
    }
}
