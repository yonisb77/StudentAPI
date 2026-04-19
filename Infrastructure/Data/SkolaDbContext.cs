using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SkolaDbContext : DbContext
{
    public SkolaDbContext(DbContextOptions<SkolaDbContext> options) : base(options) { }

    public DbSet<Kurs> Kurser { get; set; }
    public DbSet<Larare> Larare { get; set; }
}