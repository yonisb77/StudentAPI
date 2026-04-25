using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LarareController : ControllerBase
{
    private readonly IMediator _mediator;
    public LarareController(IMediator mediator) => _mediator = mediator;

    [HttpPost("skapa")]
    public async Task<IActionResult> Skapa(SkapaLarareCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok($"Lärare skapad med ID: {id}");
    }
}