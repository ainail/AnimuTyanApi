using DataAccess.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext;

public class AnimeTyanContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<TyanDto?> Tyans => Set<TyanDto>();
    public DbSet<UserDto?> Users => Set<UserDto>();
    public AnimeTyanContext() => Database.EnsureCreated();

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=tyanDb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}