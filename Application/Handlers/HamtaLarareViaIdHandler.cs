using Application.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class HamtaLarareViaIdHandler : IRequestHandler<HamtaLarareViaIdQuery, Larare?>
{
    private readonly ILarareRepository _repository;
    public HamtaLarareViaIdHandler(ILarareRepository repository) => _repository = repository;

    public async Task<Larare?> Handle(HamtaLarareViaIdQuery request, CancellationToken ct)
    {
        return await _repository.HamtaViaIdAsync(request.Id);
    }
}