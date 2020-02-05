namespace Prospa.BusinessMatcher.Api.Extensions
{
    using Prospa.BusinessMatcher.Api.Models;
    using Prospa.BusinessMatcher.Service.Models;

    public static class BusinessExtensions
    {
        public static BusinessWebModel ToViewModel(this Business model)
        {
            BusinessWebModel result = null;

            if (model != null)
            {
                result = new BusinessWebModel
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