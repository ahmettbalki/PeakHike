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
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
    {
        private readonly IRepository<Company> _repository;

        public CreateCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Company
            {
                Name = request.Name,
                City = request.City,
                Continent = request.Continent,
                Country = request.Country,
                DateJoined = request.DateJoined,
                Funding = request.Funding,
                Industry = request.Industry,
                Investors = request.Industry,
                YearFounded = request.YearFounded,
                Valuation = request.Valuation
            });
        }
    }
}
