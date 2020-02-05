namespace Prospa.BusinessMatcher.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class BusinessWebModel
    {
        [Required]
        [JsonProperty("partnerId")]
        public string PartnerId { get; set; }

        [Required]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("abnNumber")]
        public string AbnNumber { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [Required]
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
    }
}