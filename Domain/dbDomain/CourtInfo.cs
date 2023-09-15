using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.dbDomain
{
    public class CourtInfo
    {
        public int Id { get; set; }
        public string CourtName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get;set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get;set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set;}
    }
}
