using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Commands.AuthorCommands;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.AuthorCommandHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
