using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TCourtBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private IMediator? mediator;
        private ICurrentUser? currentUser;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ICurrentUser CurrentUser => currentUser ??= HttpContext.RequestServices.GetService<ICurrentUser>();

    }
}
