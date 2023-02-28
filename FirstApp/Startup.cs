using FirstApp.Infrastructure;
using FirstApp.Infrastructure.Entities;
using FirstApp.Infrastructure.Queries;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FirstApp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddScoped<AuthorQueries>();
        
        // GraphQL
        services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();
        
        // Database
        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseSqlite("Data Source=file::memory:?cache=shared");
        });
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        var hcBuilder = services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy());
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            dbContext.Database.EnsureCreated();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self"),
            });
            endpoints.MapGraphQL();
        });
        

        app.UseSwagger();
        app.UseSwaggerUI();
    }
}