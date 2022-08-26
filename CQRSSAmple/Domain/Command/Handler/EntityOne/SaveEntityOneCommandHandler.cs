using CQRSSAmple.Business.EntityOne;
using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command.Handler.EntityOne
{
    public class SaveEntityOneCommandHandler: ICommandHandler<SaveEntityOneCommand, CommandResponse>
    {
        private readonly SaveEntityOneCommand _command;
        private readonly EntityOneBusiness _business;
        public SaveEntityOneCommandHandler(SaveEntityOneCommand command, EntityOneBusiness business)
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
