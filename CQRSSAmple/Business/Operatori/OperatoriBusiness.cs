using System.Linq;
using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Domain.Command;
using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.Infrasctructure;
using CQRSSAmple.Domain.Infrasctructure.Authorization;
using CQRSSAmple.Repository;

namespace CQRSSAmple.Business.Operatori
{
    public class OperatoriBusiness: IOperatoriBusiness
    {
        private EntityContext _context;
        private readonly OperatoriRepository _repository;

        public OperatoriBusiness(EntityContext context, IOperatoriRepository repository)
        {
            _context = context;
            _repository = (OperatoriRepository)repository;
        }
        
        public Operatore GetUtente(string username, string password)
        {
            var entity = _context.Operatori.FirstOrDefault(c => c.UserName == username && c.Password == password);
            return entity;
        }

        public CommandResponse CreteToken(CreateTokenCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
           
            var utente = GetUtente(command.UserName, command.Password);
            if (utente == default)
            {
                response.Success = false;
                response.Message = "Operatore non trovato.";
                return response;
            }
            
            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("grgpla74a26g284d"))
                .AddSubject(utente.Cognome)
                .AddIssuer("Fiver.Security.Bearer")
                .AddAudience("Fiver.Security.Bearer")
                .AddClaim("ID", utente.ID.ToString())
                .AddExpiry(1440)
                .Build();
            
            response.ID = utente.ID;
            response.Success = true;
            response.Message = token.Value;
            
            return response;
        }
    }
}
