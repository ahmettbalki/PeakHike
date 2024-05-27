﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Features.Mediator.Results.ContactResults;

namespace TradeHike.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetContactQuery : IRequest<List<GetContactQueryResult>>
    {
    }
}
