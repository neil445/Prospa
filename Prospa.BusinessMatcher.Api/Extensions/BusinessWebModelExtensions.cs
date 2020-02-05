namespace Prospa.BusinessMatcher.Api.Extensions
{
    using Prospa.BusinessMatcher.Api.Models;
    using Prospa.BusinessMatcher.Service.Models;

    public static class BusinessWebModelExtensions
    {
        public static Business ToServiceModel(this BusinessWebModel model) 
        {
            Business result = null;

            if (model != null) 
            {
                result = new Business 
                {
                    AbnNumber = model.AbnNumber,
                    Address = model.Address,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Name = model.Name,
                    PartnerId = model.PartnerId
                };
            }

            return result;
        }
    }
}