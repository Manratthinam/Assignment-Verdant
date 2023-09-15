using Application.Common.Interface;
using Application.Core.Court.Command;
using Application.Core.Court.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.CommandHandler
{
    public class DeleteCourtInfoCommandHandler : IRequestHandler<DeleteCourtInfoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly ICourtInfoService _courtService;
        public DeleteCourtInfoCommandHandler(IMediator mediator, ICourtInfoService courtService)
        {
            _mediator = mediator;
            _courtService = courtService;
        }

        public async Task<bool> Handle(DeleteCourtInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var courtInfo = await _mediator.Send(new GetCourtInfoQuery(request.courtId));
                if(courtInfo == null) { return false; }
                else
                {
                   return await _courtService.DeleteCourtInfo(courtInfo);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
