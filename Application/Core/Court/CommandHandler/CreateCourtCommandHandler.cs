using Application.Common;
using Application.Common.Interface;
using Application.Core.Court.Command;
using Domain.dbDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.CommandHandler
{
    public class CreateCourtCommandHandler : IRequestHandler<CreateCourtCommand, bool>
    {
        private readonly ICourtInfoService _courtInfoService;
        private readonly ICurrentUser _currentUser;
        public CreateCourtCommandHandler(ICourtInfoService courtInfoService,ICurrentUser currentUser)
        {
            _courtInfoService = courtInfoService;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(CreateCourtCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var courtInfo = request.courtInfo;
                CourtInfo court = new CourtInfo
                {
                    Address = courtInfo.Address,
                    ContactNumber = courtInfo.PhoneNumber,
                    CourtName = courtInfo.CourtName,
                    CreatedBy = _currentUser.UserId,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = _currentUser.UserId,
                    ModifiedOn = DateTime.UtcNow,
                };
                return await _courtInfoService.CreateCourt(court);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
