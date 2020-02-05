namespace Prospa.BusinessMatcher.Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Business
    {
        public string PartnerId { get; set; }
        
        public string Address { get; set; }
        
        public string AbnNumber { get; set; }
        
        public string Name { get; set; }
        
        public decimal Latitude { get; set; }
        
        public decimal Longitude { get; set; }
    }
}
