using Domain.dbDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface ICourtInfoService
    {
        Task<bool> CreateCourt(CourtInfo courtInfo);

        Task<CourtInfo> GetCourtInfo(int courtId);
        Task<bool> UpdateCourtInfo(CourtInfo courtInfo);
        Task<bool> DeleteCourtInfo(CourtInfo court);
        Task<string> ListOfCourts();
    }
}
