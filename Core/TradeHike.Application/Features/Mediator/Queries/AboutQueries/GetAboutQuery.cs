using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Results.AboutResults;

namespace TradeHike.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutQuery : IRequest<List<GetAboutQueryResult>>
    {
    }
}
