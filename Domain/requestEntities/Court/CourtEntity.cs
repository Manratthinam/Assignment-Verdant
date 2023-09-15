using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.requestEntities.Court
{
    public class CourtEntity
    {
        public string CourtName { get;set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get;set; }
        public string Address2 { get;set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string? Address { get
            {
                return $"{this.Address1}, {this.Address2 +","} {this.City}, {this.State}, {this.ZipCode}";
            } 
        }
    }
}
