using Application.Common.Interface;
using Application.Core.Court.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.QueryHandler
{
    public class GetListOfCourtQueryHandler : IRequestHandler<GetListOfCourtsQuery, string>
    {
        private readonly ICourtInfoService _courtService;
        public GetListOfCourtQueryHandler(ICourtInfoService courtService)
        {
            _courtService = courtService;
        }
        public Task<string> Handle(GetListOfCourtsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _courtService.ListOfCourts();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
