using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Queries.BannerQueries;
using TradeHike.Application.Features.Mediator.Results.BannerResults;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBannerByIdQueryResult
            {
                Id = values.Id,
                Description = values.Description,
                Title = values.Title
            };
        }
    }
}
