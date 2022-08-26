using CQRSSAmple.Business.EntityTwo;
using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command.Handler.EntityTwo
{
    public class SaveEntityTwoCommandHandler: ICommandHandler<SaveEntityTwoCommand, CommandResponse>
    {
        private readonly SaveEntityTwoCommand _command;
        private readonly EntityTwoBusiness _business;
        public SaveEntityTwoCommandHandler(SaveEntityTwoCommand command, EntityTwoBusiness business)
        {
            _command = command;
            _business = business;
        }
        public CommandResponse Execute()
        {
            return _business.Save(_command);
        }
    }
}
