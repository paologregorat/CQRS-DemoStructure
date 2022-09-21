using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.Infrasctructure.Authorization;

namespace CQRSSAmple.Business.Abstract
{
    public interface IOperatoriBusiness
    {
        public Operatore GetUtente(string username, string password);

        public CommandResponse CreteToken(CreateTokenCommand command);

    }
}
