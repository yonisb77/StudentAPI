using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LarareController : ControllerBase
{
    private readonly IMediator _mediator;
    public LarareController(IMediator mediator) => _mediator = mediator;

    [HttpGet("hamta-alla")]
    public async Task<IActionResult> HamtaAlla()
    {
        var larare = await _mediator.Send(new HamtaAllaLarareQuery());
        return Ok(larare);
    }

    [HttpPost("skapa")]
    public async Task<IActionResult> Skapa(SkapaLarareCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok($"Lärare skapad med ID: {id}");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> HamtaViaId(int id)
    {
        var larare = await _mediator.Send(new HamtaLarareViaIdQuery(id));
        if (larare == null) return NotFound();
        return Ok(larare);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Uppdatera(int id, UppdateraLarareCommand command)
    {
        if (id != command.Id) return BadRequest("Id matchar inte.");
        var result = await _mediator.Send(command);
        if (!result) return NotFound();
        return Ok("Lärare uppdaterad.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Radera(int id)
    {
        var result = await _mediator.Send(new RaderaLarareCommand(id));
        if (!result) return NotFound();
        return Ok("Lärare raderad.");
    }
}