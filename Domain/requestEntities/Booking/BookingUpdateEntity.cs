using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.requestEntities.Booking
{
    public class BookingUpdateEntity
    {
        public int CourtId { get;set; }
        public string PreviousBookedTime { get;set; }
        public string UpdatedBookedTime { get;set; }
    }
}
