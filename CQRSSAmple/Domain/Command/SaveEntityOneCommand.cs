using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command
{
    public class SaveEntityOneCommand : ICommand<CommandResponse>
    {
    public EntityOne EntityOne { get; private set; }
    public SaveEntityOneCommand(EntityOne item)
    {
        EntityOne = item;
    }
    }
}
