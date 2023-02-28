using FirstApp.Infrastructure.Entities;

namespace FirstApp.Infrastructure.Queries;

public class Query
{
    [UseSorting]
    public IQueryable<Author> GetAuthors([Service] LibraryDbContext libraryDbContext) =>
        libraryDbContext.AuthorTable.AsQueryable();
}