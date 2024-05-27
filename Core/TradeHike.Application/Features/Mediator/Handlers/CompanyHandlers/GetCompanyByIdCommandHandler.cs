using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Queries.CompanyQueries;
using TradeHike.Application.Features.Mediator.Results.CompaniesResults;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.CompanyHandlers
{
    public class GetCompanyByIdCommandHandler : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResult>
    {
        private readonly IRepository<Company> _repository;

        public GetCompanyByIdCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<GetCompanyByIdQueryResult> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCompanyByIdQueryResult
            {
                Id = values.Id,
                YearFounded = values.YearFounded,
                Valuation = values.Valuation,
                Investors = values.Investors,
                Industry = values.Industry,
                Funding = values.Funding,
                DateJoined = values.DateJoined,
                Country = values.Country,
                Continent = values.Continent,
                City = values.City,
                Name = values.Name
            };
        }
    }
}
