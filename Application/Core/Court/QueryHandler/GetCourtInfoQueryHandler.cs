using Application.Common.Interface;
using Application.Core.Court.Query;
using Domain.dbDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.QueryHandler
{
    public class GetCourtInfoQueryHandler : IRequestHandler<GetCourtInfoQuery, CourtInfo>
    {
        private readonly ICourtInfoService _courtInfoService;
        public GetCourtInfoQueryHandler(ICourtInfoService courtInfoService) {
            _courtInfoService = courtInfoService;
        }

        public async Task<CourtInfo> Handle(GetCourtInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var courtInfo = await _courtInfoService.GetCourtInfo(request.id);
                return courtInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
