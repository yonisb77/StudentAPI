using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers;

public class UppdateraKursHandler : IRequestHandler<UppdateraKursCommand, bool>
{
    private readonly IKursRepository _repository;
    public UppdateraKursHandler(IKursRepository repository) => _repository = repository;

    public async Task<bool> Handle(UppdateraKursCommand request, CancellationToken ct)
    {
        var kurs = await _repository.HamtaViaIdAsync(request.Id);
        if (kurs == null) return false;

        kurs.Kursnamn = request.Kursnamn;
        kurs.Poang = request.Poang;
        kurs.LarareId = request.LarareId;

        await _repository.UppdateraAsync(kurs);
        return true;
    }
}