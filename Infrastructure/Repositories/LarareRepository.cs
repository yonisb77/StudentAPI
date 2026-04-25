using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class LarareRepository : ILarareRepository
{
    private readonly SkolaDbContext _context;
    public LarareRepository(SkolaDbContext context) => _context = context;

    public async Task<int> SkapaAsync(Larare larare)
    {
        _context.Larare.Add(larare);
        await _context.SaveChangesAsync();
        return larare.Id;
    }
}