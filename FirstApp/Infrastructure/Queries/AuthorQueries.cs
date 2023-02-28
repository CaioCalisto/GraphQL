using FirstApp.Infrastructure.Entities;

namespace FirstApp.Infrastructure.Queries;

public class AuthorQueries
{
    private readonly LibraryDbContext _appDbContext;

    public AuthorQueries(LibraryDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<Author> Get() => _appDbContext.AuthorTable.AsQueryable();
}