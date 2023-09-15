using Application.Common;
using Application.Common.Interface;
using Application.Core.Court.Command;
using Application.Core.Court.Query;
using Application.Core.Court.QueryHandler;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.CommandHandler
{
    public class UpdateCourtInfoCommandHandler : IRequestHandler<UpdateCourtInfoCommand, bool>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMediator _mediator;
        private readonly ICourtInfoService _courtInfoService;
        public UpdateCourtInfoCommandHandler(ICurrentUser currentUser, IMediator mediator, ICourtInfoService courtInfoService)
        {
            _currentUser = currentUser;
            _mediator = mediator;
            _courtInfoService = courtInfoService;
        }

        public async Task<bool> Handle(UpdateCourtInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var courtData = await _mediator.Send(new GetCourtInfoQuery(request.courtId));
                var courtInfo = request.courtInfo;
                if(courtData == null) { return false; }
                else
                {
                    courtData.ModifiedOn = DateTime.UtcNow;
                    courtData.ModifiedBy = _currentUser.UserId;
                    courtData.Address = courtInfo.Address;
                    courtData.ContactNumber = courtInfo.PhoneNumber;
                    courtData.CourtName = courtInfo.CourtName;
                    
                    return await _courtInfoService.UpdateCourtInfo(courtData);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
