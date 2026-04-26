using Domain.Entities;

namespace Domain.Interfaces;

public interface ILarareRepository
{
    Task<IEnumerable<Larare>> HamtaAllaAsync();
    Task<Larare?> HamtaViaIdAsync(int id);
    Task<int> SkapaAsync(Larare larare);
    Task UppdateraAsync(Larare larare);
    Task RaderaAsync(int id);
}