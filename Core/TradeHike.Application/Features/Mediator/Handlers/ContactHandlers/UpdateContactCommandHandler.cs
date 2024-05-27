using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Commands.ContactCommands;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.SendDate = request.SendDate;
            values.Subject = request.Subject;
            values.Email = request.Email;
            values.Message = request.Message;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
