using Domain.Entities;

namespace Domain.Interfaces;

public interface IKursRepository
{
    Task<IEnumerable<Kurs>> HamtaAllaAsync();
    Task<Kurs> HamtaViaIdAsync(int id);
    Task SkapaAsync(Kurs kurs);
    Task UppdateraAsync(Kurs kurs);
    Task RaderaAsync(int id);
}