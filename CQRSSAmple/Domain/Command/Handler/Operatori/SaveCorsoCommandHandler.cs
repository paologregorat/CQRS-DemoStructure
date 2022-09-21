﻿using CQRSSAmple.Business.Abstract;
using CQRSSAmple.Business.Operatori;
using CQRSSAmple.Domain.Command.Abstract;
using CQRSSAmple.Domain.Entity;

namespace CQRSSAmple.Domain.Command.Handler.Operatori
{
    public class CreteTokenCommandHandler : ICommandHandler<CreateTokenCommand, CommandResponse>
    {
        private readonly CreateTokenCommand _command;
        private readonly IOperatoriBusiness _business;
        public CreteTokenCommandHandler(CreateTokenCommand command, IOperatoriBusiness business)
        {
            _command = command;
            _business = business;
        }
        public CommandResponse Execute()
        {
            return _business.CreteToken(_command);
        }
    }
}
