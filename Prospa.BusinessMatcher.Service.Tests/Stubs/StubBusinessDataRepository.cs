using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prospa.BusinessMatcher.Service.Data;
using Prospa.BusinessMatcher.Service.Models;

namespace Prospa.BusinessMatcher.Service.Tests.Stubs
{
    class StubBusinessDataRepository : IBusinessDataRepository
    {
        public bool UpdateFlag = false;
        public bool InsertFlag = false;

        public Task<Business> Delete(string abnNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Business>> GetAllASync()
        {
            return Task.FromResult(CreateDefaultData().AsQueryable());
        }

        public Task<IQueryable<Business>> GetByPartnerId(string partnerId)
        {
            return Task.FromResult(CreateDefaultData().Where(b => b.PartnerId.Equals(partnerId)).AsQueryable());
        }

        public Task<Business> GetByAbnNumber(string abnNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Business> InsertAsync(Business business)
        {
            this.InsertFlag = true;
            return Task.FromResult(new Business());
        }

        public Task<Business> UpdateAsync(Business business)
        {
            this.UpdateFlag = true;
            return Task.FromResult(new Business());
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
                    Name= "Awesome Coffee House, Sydney",
                    Latitude = -33.828873m,
                    Longitude = 151.2258373m
                },
                new Business
                {
                    PartnerId = "ELF",
                    AbnNumber = "2",
                    Address = "Ground Floor, Petron Megaplaza, 358, Sen. Gil Puyat Avenue, Makati, 1200 Metro Manila",
                    Name= "Gloria Jeans Coffee",
                    Latitude = 14.5618151m,
                    Longitude = 121.0233626m
                },
                new Business
                {
                    PartnerId = "CL",
                    AbnNumber = "3",
                    Address = "South Rd, Poblacion, Sagada, 2619 Mountain Province",
                    Name= "The best coffee house",
                    Latitude = 17.0811811m,
                    Longitude = 120.9001565m
                }
            };
        }
    }
}
