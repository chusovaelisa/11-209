using Microsoft.EntityFrameworkCore;
using PockemonAPI22.DataAccess.Entities;

namespace PockemonAPI22.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Breeding> Breedings { get; set; }
    public DbSet<Pockemon> Pockemons { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}