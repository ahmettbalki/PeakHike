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
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IRepository<Company> _repository;

        public UpdateCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Industry = request.Industry;
            values.Investors = request.Investors;
            values.Valuation = request.Valuation;
            values.City = request.City;
            values.Country = request.Country;
            values.Continent = request.Continent;
            values.DateJoined = request.DateJoined;
            values.Funding = request.Funding;
            values.Name = request.Name;
            values.YearFounded = request.YearFounded;
            await _repository.UpdateAsync(values);
        }
    }
}
