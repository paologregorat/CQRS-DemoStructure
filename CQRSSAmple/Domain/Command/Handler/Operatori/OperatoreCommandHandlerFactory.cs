using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.Operatori;
using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command.Handler.Operatori
{
    public static class OperatoreCommandHandlerFactory
    {
        public static ICommandHandler<CreateTokenCommand, CommandResponse> Build(CreateTokenCommand command, IOperatoriBusiness business)
        {
            return new CreteTokenCommandHandler(command, business);
        }
    }
}
