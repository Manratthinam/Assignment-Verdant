using Application.Common.Interface;
using Domain.dbDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.services
{
    public class CourtInfoService : ICourtInfoService
    {
        private readonly TCourtContext _courtContext;
        public CourtInfoService(TCourtContext courtContext)
        {
            _courtContext = courtContext;
        }

        public async Task<bool> CreateCourt(CourtInfo courtInfo)
        {
            try
            {
                await _courtContext.AddAsync(courtInfo);
                await _courtContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCourtInfo(CourtInfo court)
        {
            try
            {
                 _courtContext.CourtInfo.Remove(court);
                _courtContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CourtInfo> GetCourtInfo(int courtId)
        {
            try
            {
                var courtInfo = await _courtContext.CourtInfo.FirstOrDefaultAsync(x=>x.Id == courtId);
                return courtInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> ListOfCourts()
        {
            try
            {
                var courts = _courtContext.CourtInfo.ToList();
                return JsonSerializer.Serialize(courts);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> UpdateCourtInfo(CourtInfo courtInfo)
        {
            try
            {
                 _courtContext.Update(courtInfo);
                _courtContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
