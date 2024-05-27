using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHike.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
