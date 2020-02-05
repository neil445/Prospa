namespace Prospa.BusinessMatcher.Service.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Prospa.BusinessMatcher.Service.Models;

    public interface IBusinessDataRepository
    {
        Task<Business> InsertAsync(Business business);
        
        Task<Business> Delete(string abnNumber);

        Task<IQueryable<Business>> GetByPartnerId(string partnerId);

        Task<Business> GetByAbnNumber(string abnNumber);
        
        Task<IQueryable<Business>> GetAllASync();

        Task<Business> UpdateAsync(Business business);
    }
}