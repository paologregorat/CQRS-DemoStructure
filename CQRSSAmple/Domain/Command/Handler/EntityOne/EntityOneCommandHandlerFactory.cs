using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command.Handler.EntityOne
{
    public class EntityOneCommandHandlerFactory
    {
        public static ICommandHandler<SaveEntityOneCommand, CommandResponse> Build(SaveEntityOneCommand command, EntityOneBusiness business)
        {
            return new SaveEntityOneCommandHandler(command, business);
        }
    }
}