﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Queries.BlogQueries;
using TradeHike.Application.Features.Mediator.Results.BlogResults;
using TradeHike.Application.Interfaces;

namespace TradeHike.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                Id = x.Id,
                CoverImageUrl = x.CoverImageUrl,
                CreatedTime = x.CreatedTime,
                Title = x.Title,
                AuthorName = x.Author.Name,
                Description = x.Description,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl
            }).ToList();
        }
    }
}
