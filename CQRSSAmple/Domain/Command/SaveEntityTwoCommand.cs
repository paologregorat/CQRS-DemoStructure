using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command
{
    public class SaveEntityTwoCommand : ICommand<CommandResponse>
    {
    public EntityTwo EntityTwo { get; private set; }
    public SaveEntityTwoCommand(EntityTwo item)
    {
        EntityTwo = item;
    }
    }
}
