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
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, List<GetCompanyQueryResult>>
    {
        private readonly IRepository<Company> _repository;

        public GetCompanyQueryHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCompanyQueryResult>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCompanyQueryResult
            {
                City = x.City,
                Country = x.Country,
                Continent = x.Continent,
                DateJoined = x.DateJoined,
                Funding = x.Funding,
                Industry = x.Industry,
                Investors = x.Industry,
                Valuation = x.Valuation,
                YearFounded = x.YearFounded,
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }
    }
}
