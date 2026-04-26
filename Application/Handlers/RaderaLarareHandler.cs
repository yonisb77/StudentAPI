using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class RaderaLarareHandler : IRequestHandler<RaderaLarareCommand, bool>
{
    private readonly ILarareRepository _repository;
    public RaderaLarareHandler(ILarareRepository repository) => _repository = repository;

    public async Task<bool> Handle(RaderaLarareCommand request, CancellationToken ct)
    {
        var larare = await _repository.HamtaViaIdAsync(request.Id);
        if (larare == null) return false;

        await _repository.RaderaAsync(request.Id);
        return true;
    }
}