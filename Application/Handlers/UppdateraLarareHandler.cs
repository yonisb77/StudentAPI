using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class UppdateraLarareHandler : IRequestHandler<UppdateraLarareCommand, bool>
{
    private readonly ILarareRepository _repository;
    public UppdateraLarareHandler(ILarareRepository repository) => _repository = repository;

    public async Task<bool> Handle(UppdateraLarareCommand request, CancellationToken ct)
    {
        var larare = await _repository.HamtaViaIdAsync(request.Id);
        if (larare == null) return false;

        larare.Namn = request.Namn;
        await _repository.UppdateraAsync(larare);
        return true;
    }
}