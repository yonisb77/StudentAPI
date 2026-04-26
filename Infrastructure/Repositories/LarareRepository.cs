using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LarareRepository : ILarareRepository
{
    private readonly SkolaDbContext _context;
    public LarareRepository(SkolaDbContext context) => _context = context;

    public async Task<IEnumerable<Larare>> HamtaAllaAsync()
        => await _context.Larare.ToListAsync();

    public async Task<Larare?> HamtaViaIdAsync(int id)
        => await _context.Larare.FindAsync(id);

    public async Task<int> SkapaAsync(Larare larare)
    {
        _context.Larare.Add(larare);
        await _context.SaveChangesAsync();
        return larare.Id;
    }

    public async Task UppdateraAsync(Larare larare)
    {
        _context.Larare.Update(larare);
        await _context.SaveChangesAsync();
    }

    public async Task RaderaAsync(int id)
    {
        var larare = await _context.Larare.FindAsync(id);
        if (larare != null)
        {
            _context.Larare.Remove(larare);
            await _context.SaveChangesAsync();
        }
    }
}