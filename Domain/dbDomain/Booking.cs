using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.dbDomain
{
    public class Booking
    {
        public int BookingId { get;set; }
        public int UserId { get; set; }
        public int CourtInfoId { get; set; }
        public DateTime BookingDate { get;set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set;}

        public User user { get; set; }
        public CourtInfo courtInfo { get;set; }
    }
}
