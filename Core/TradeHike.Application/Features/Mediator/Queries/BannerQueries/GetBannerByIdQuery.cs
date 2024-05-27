using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Results.BannerResults;

namespace TradeHike.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBannerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
