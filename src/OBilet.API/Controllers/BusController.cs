using MediatR;
using Microsoft.AspNetCore.Mvc;
using OBilet.API.Attributes;
using OBilet.Application.Features.BusJourney.Queries;
using OBilet.Application.Features.BusLocation.Queries;
using OBilet.Application.Features.Session.Queries;

namespace OBilet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController(ISender _mediator) : ControllerBase
    {
        [HttpGet("location")]
        public async Task<IActionResult> GetBusLocation([FromQuery] BusLocationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("journey")]
        public async Task<IActionResult> GetBusJourney([FromQuery] BusJourneyQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [NonSession]
        [HttpGet("session")]
        public async Task<IActionResult> GetBusSession([FromQuery] SessionQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
