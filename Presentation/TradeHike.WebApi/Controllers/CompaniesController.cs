using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeHike.Application.Features.Mediator.Commands.CompanyCommands;
using TradeHike.Application.Features.Mediator.Queries.CompanyQueries;

namespace TradeHike.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CompanyList()
        {
            var values = await _mediator.Send(new GetCompanyQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var value = await _mediator.Send(new GetCompanyByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand command)
        {
            await _mediator.Send(command);
            return Ok("Şirket başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            await _mediator.Send(new RemoveCompanyCommand(id));
            return Ok("Şirket başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommand command)
        {
            await _mediator.Send(command);
            return Ok("Şirket başarıyla güncellendi");
        }
    }
}
