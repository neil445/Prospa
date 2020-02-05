namespace Prospa.BusinessMatcher.Service.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Prospa.BusinessMatcher.Service.Models;

    /// <summary>
    /// Made a repository to simulate database access.
    /// </summary>
    public class BusinessDataRepository : IBusinessDataRepository
    {
        private static ICollection<Business> businessStore;

        public BusinessDataRepository()
        {
            if (businessStore == null) 
            {
                businessStore = CreateDefaultData();
            }
        }

        public Task<IQueryable<Business>> GetAllASync()
        {
            return Task.FromResult(businessStore.AsQueryable());
        }

        public Task<IQueryable<Business>> GetByPartnerId(string partnerId)
        {
            return Task.FromResult(businessStore.Where(b => b.PartnerId.Equals(partnerId)).AsQueryable());
        }

        public Task<Business> GetByAbnNumber(string abnNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Business> InsertAsync(Business business)
        {
            businessStore.Add(business);
            return Task.FromResult(business);
        }

        public Task<Business> UpdateAsync(Business business)
        {
            businessStore.Add(business);
            return Task.FromResult(business);
        }

        public Task<Business> Delete(string abnNumber)
        {
            throw new NotImplementedException();
        }

        private static ICollection<Business> CreateDefaultData() 
        {
            return new List<Business>
            {
                new Business
                {
                    PartnerId = "LF",
                    AbnNumber = "1",
                    Address = "32 Sir John Young Crescent, Sydney NSW",
                    Name = "Awesome Coffee House, Sydney",
                    Latitude = -33.828873m,
                    Longitude = 151.2258373m
                },
                new Business
                {
                    PartnerId = "ELF",
                    AbnNumber = "2",
                    Address = "Ground Floor, Petron Megaplaza, 358, Sen. Gil Puyat Avenue, Makati, 1200 Metro Manila",
                    Name = "Gloria Jeans Coffee",
                    Latitude = 14.5618151m,
                    Longitude = 121.0233626m
                },
                new Business
                {
                    PartnerId = "CL",
                    AbnNumber = "3",
                    Address = "South Rd, Poblacion, Sagada, 2619 Mountain Province",
                    Name = "The best coffee house",
                    Latitude = 17.0811811m,
                    Longitude = 120.9001565m
                }
            };
        }
    }
}
