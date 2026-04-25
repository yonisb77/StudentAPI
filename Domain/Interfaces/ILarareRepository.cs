using Domain.Entities;

namespace Domain.Interfaces;

public interface ILarareRepository
{
    Task<int> SkapaAsync(Larare larare);
}