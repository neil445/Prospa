namespace Prospa.BusinessMatcher.Service
{
    using System.Threading.Tasks;
    using Prospa.BusinessMatcher.Service.Models;

    public interface IBusinessRecordsService
    {
        /// <summary>
        /// Create business record, update if the business record already exists.
        /// </summary>
        /// <param name="business">business information</param>
        /// <returns>saved business information</returns>
        Task<Business> CreateOrUpdateBusinessRecordAsync(Business business);
    }
}