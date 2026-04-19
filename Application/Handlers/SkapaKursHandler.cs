using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers
{
    public class SkapaKursHandler : IRequestHandler<SkapaKursCommand, int>
    {
        private readonly IKursRepository _repository;

        public SkapaKursHandler(IKursRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(SkapaKursCommand request, CancellationToken ct)
        {
            // Validering (Commit 4)
            if (string.IsNullOrWhiteSpace(request.Kursnamn))
            {
                throw new ArgumentException("Kursnamn får inte vara tomt.");
            }

            // Loggning (Commit 5)
            Console.WriteLine($"[LOG]: Skapar kurs: {request.Kursnamn}");

            var nyKurs = new Kurs
            {
                Kursnamn = request.Kursnamn,
                Poang = request.Poang,
                LarareId = request.LarareId
            };

            await _repository.SkapaAsync(nyKurs);
            return nyKurs.Id;
        }
    }
}