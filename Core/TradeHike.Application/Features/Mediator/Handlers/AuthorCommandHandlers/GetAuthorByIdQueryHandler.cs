using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Queries.AuthorQueries;
using TradeHike.Application.Features.Mediator.Results.AuthorResults;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.AuthorCommandHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Description = values.Description,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
