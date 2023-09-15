using Domain.requestEntities.Auth;
using MediatR;

namespace Application.Core.Auth.SignIn.Command
{

    public record SigInCommand(SiginEntity sigin) : IRequest<bool>;

}
