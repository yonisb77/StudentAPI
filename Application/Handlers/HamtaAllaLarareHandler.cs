using Application.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class HamtaAllaLarareHandler : IRequestHandler<HamtaAllaLarareQuery, IEnumerable<Larare>>
{
    private readonly ILarareRepository _repository;
    public HamtaAllaLarareHandler(ILarareRepository repository) => _repository = repository;

    public async Task<IEnumerable<Larare>> Handle(HamtaAllaLarareQuery request, CancellationToken ct)
    {
        return await _repository.HamtaAllaAsync();
    }
}