using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KursController : ControllerBase
{
    private readonly IMediator _mediator;
    public KursController(IMediator mediator) => _mediator = mediator;

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
        return Ok($"Kurs skapad med ID: {kursId}");
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> HamtaViaId(int id)
    {
        var kurs = await _mediator.Send(new HamtaKursViaIdQuery(id));
        if (kurs == null) return NotFound();
        return Ok(kurs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Uppdatera(int id, UppdateraKursCommand command)
    {
        if (id != command.Id) return BadRequest("Id matchar inte.");
        var result = await _mediator.Send(command);
        if (!result) return NotFound();
        return Ok("Kurs uppdaterad.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Radera(int id)
    {
        var result = await _mediator.Send(new RaderaKursCommand(id));
        if (!result) return NotFound();
        return Ok("Kurs raderad.");
    }

}