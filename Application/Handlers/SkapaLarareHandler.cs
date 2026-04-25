using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class SkapaLarareHandler : IRequestHandler<SkapaLarareCommand, int>
{
    private readonly ILarareRepository _repository;
    public SkapaLarareHandler(ILarareRepository repository) => _repository = repository;

    public async Task<int> Handle(SkapaLarareCommand request, CancellationToken ct)
    {
        var larare = new Larare { Namn = request.Namn };
        await _repository.SkapaAsync(larare);
        return larare.Id;
    }
}