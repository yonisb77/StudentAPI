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
            // COMMIT 4: Validering - Kontrollera att kursnamnet inte är tomt
            if (string.IsNullOrWhiteSpace(request.Kursnamn))
            {
                throw new ArgumentException("Kursnamn får inte vara tomt.");
            }

            // EXTRA: Loggning för att spåra aktivitet i konsolen
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