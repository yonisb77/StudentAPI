using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class KursRepository : IKursRepository
{
    private readonly SkolaDbContext _context;
    public KursRepository(SkolaDbContext context) => _context = context;

    public async Task<IEnumerable<Kurs>> HamtaAllaAsync()
        => await _context.Kurser.ToListAsync();

    public async Task<Kurs> HamtaViaIdAsync(int id)
        => await _context.Kurser.FindAsync(id);

    public async Task SkapaAsync(Kurs kurs)
    {
        _context.Kurser.Add(kurs);
        await _context.SaveChangesAsync();
    }

    public async Task UppdateraAsync(Kurs kurs)
    {
        _context.Kurser.Update(kurs);
        await _context.SaveChangesAsync();
    }

    public async Task RaderaAsync(int id)
    {
        var kurs = await _context.Kurser.FindAsync(id);
        if (kurs != null)
        {
            _context.Kurser.Remove(kurs);
            await _context.SaveChangesAsync();
        }
    }
}