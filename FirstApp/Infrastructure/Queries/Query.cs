using FirstApp.Infrastructure.Entities;

namespace FirstApp.Infrastructure.Queries;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Author> GetAuthors([Service] LibraryDbContext libraryDbContext) =>
        libraryDbContext.AuthorTable.AsQueryable();
}

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(q => q.GetAuthors(default))
            .UsePaging();
    }
}