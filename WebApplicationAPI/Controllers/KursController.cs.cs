using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KursController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("hamta-alla")]
        public async Task<IActionResult> HamtaAlla()
        {
            var kurser = await _mediator.Send(new HamtaAllaKurserQuery());
            return Ok(kurser);
        }

        [HttpPost("skapa")]
        public async Task<IActionResult> Skapa(SkapaKursCommand command)
        {
            var kursId = await _mediator.Send(command);
            
            // Returnerar 201 Created istället för bara OK
            return CreatedAtAction(nameof(Skapa), new { id = kursId }, "Kursen har skapats framgångsrikt.");
        }
    }
}
