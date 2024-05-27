using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHike.Application.Features.Mediator.Commands.CompanyCommands
{
    public class RemoveCompanyCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCompanyCommand(int id)
        {
            Id = id;
        }
    }
}
