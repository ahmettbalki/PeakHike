using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Commands.CompanyCommands;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.CompanyHandlers
{
    public class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommand>
    {
        private readonly IRepository<Company> _repository;

        public RemoveCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
