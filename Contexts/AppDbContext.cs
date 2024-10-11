using ApiDockerStudy.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiDockerStudy.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions option)
        : base(option)
    {
    }

    public DbSet<Book> Books { get; set; }
}
