using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Commands.BannerCommands;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Banner
            {
                Title = request.Title,
                Description = request.Description,
            });
        }
    }

}
