using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Queries.ContactQueries;
using TradeHike.Application.Features.Mediator.Results.ContactResults;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class GetContactByIdCommandHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetContactByIdQueryResult
            {
                Id = values.Id,
                Subject = values.Subject,
                SendDate = values.SendDate,
                Name = values.Name,
                Message = values.Message,
                Email = values.Email
            };
        }
    }
}
