using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Results.CompaniesResults;

namespace TradeHike.Application.Features.Mediator.Queries.CompanyQueries
{
    public class GetCompanyQuery : IRequest<List<GetCompanyQueryResult>>
    {
    }
}
