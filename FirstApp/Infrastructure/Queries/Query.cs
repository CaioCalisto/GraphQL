using FirstApp.Infrastructure.Entities;

namespace FirstApp.Infrastructure.Queries;

public class Query
{
    public IQueryable<Author> GetAuthors([Service] LibraryDbContext libraryDbContext) =>
        libraryDbContext.AuthorTable.AsQueryable();
}