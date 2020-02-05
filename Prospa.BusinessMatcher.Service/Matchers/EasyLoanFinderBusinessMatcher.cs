namespace Prospa.BusinessMatcher.Service.Matchers
{
    using System;
    using Prospa.BusinessMatcher.Service.Models;

    internal class EasyLoanFinderBusinessMatcher : IBusinessMatcher
    {
        public bool IsMatch(Business business, Business databaseBusiness)
        {
            // C# library supported code
            // GeoCoordinate businessCoordinates = new GeoCoordinate(decimal.ToDouble(business.Latitude), decimal.ToDouble(business.Longitude));
            // GeoCoordinate databaseBusinessCoordinates = new GeoCoordinate(decimal.ToDouble(databaseBusiness.Latitude), decimal.ToDouble(databaseBusiness.Longitude));
            // double distance = databaseBusinessCoordinates.GetDistanceTo(businessCoordinates);

            // haversine formula
            var deltaLatitude = (decimal.ToDouble(business.Latitude) - decimal.ToDouble(databaseBusiness.Latitude)) * (Math.PI / 180.0);
            var deltaLongitude = (decimal.ToDouble(business.Longitude) - decimal.ToDouble(databaseBusiness.Longitude)) * (Math.PI / 180.0);

            var a = Math.Pow(Math.Sin(deltaLatitude / 2), 2.0) +
                Math.Cos(decimal.ToDouble(databaseBusiness.Latitude) * (Math.PI / 180.0)) *
                Math.Cos(decimal.ToDouble(business.Latitude) * (Math.PI / 180.0)) *
                Math.Pow(Math.Sin(deltaLongitude / 2), 2.0);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));
            var distanceInMeters = 6376500.0 * c;

            var result = distanceInMeters <= 200;

            return result;
        }
    }
}
