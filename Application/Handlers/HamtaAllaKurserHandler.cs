using Application.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class HamtaAllaKurserHandler : IRequestHandler<HamtaAllaKurserQuery, IEnumerable<Kurs>>
{
    private readonly IKursRepository _repository;
    public HamtaAllaKurserHandler(IKursRepository repository) => _repository = repository;

    public async Task<IEnumerable<Kurs>> Handle(HamtaAllaKurserQuery request, CancellationToken ct)
    {
        return await _repository.HamtaAllaAsync();
    }
}