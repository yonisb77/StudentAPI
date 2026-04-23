using Application.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class HamtaKursViaIdHandler : IRequestHandler<HamtaKursViaIdQuery, Kurs?>
{
    private readonly IKursRepository _repository;
    public HamtaKursViaIdHandler(IKursRepository repository) => _repository = repository;

    public async Task<Kurs?> Handle(HamtaKursViaIdQuery request, CancellationToken ct)
    {
        return await _repository.HamtaViaIdAsync(request.Id);
    }
}