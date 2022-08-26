using CQRSSAmple.Business.EntityTwo;
using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command.Handler.EntityTwo
{
    public class EntityTwoCommandHandlerFactory
    {
        public static ICommandHandler<SaveEntityTwoCommand, CommandResponse> Build(SaveEntityTwoCommand command, EntityTwoBusiness business)
        {
            return new SaveEntityTwoCommandHandler(command, business);
        }
    }
}