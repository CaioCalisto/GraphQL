using FirstApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Infrastructure;

public class LibraryDbContext : DbContext
{
    public DbSet<Entities.Author> AuthorTable { get; set; }

    public DbSet<Entities.Book> BookTable { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Entities.Author>().HasData(new List<Author>()
        {
            new Author(){ Id = 1, Name = "Caio", BornDate = DateOnly.Parse("1988-08-20")},
            new Author(){ Id = 2, Name = "Tiago", BornDate = DateOnly.Parse("1988-08-20")},
            new Author(){ Id = 3, Name = "Bruno", BornDate = DateOnly.Parse("1988-08-20")},
            new Author(){ Id = 4, Name = "Ednilson", BornDate = DateOnly.Parse("1988-08-20")},
        });
    }
}