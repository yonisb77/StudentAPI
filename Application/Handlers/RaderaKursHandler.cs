using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class RaderaKursHandler : IRequestHandler<RaderaKursCommand, bool>
{
    private readonly IKursRepository _repository;
    public RaderaKursHandler(IKursRepository repository) => _repository = repository;

    public async Task<bool> Handle(RaderaKursCommand request, CancellationToken ct)
    {
        var kurs = await _repository.HamtaViaIdAsync(request.Id);
        if (kurs == null) return false;

        await _repository.RaderaAsync(request.Id);
        return true;
    }
}