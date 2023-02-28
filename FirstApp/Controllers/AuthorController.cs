using FirstApp.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorQueries _queries;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(AuthorQueries queries, ILogger<AuthorController> logger)
    {
        _queries = queries;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_queries.Get().ToList());
    }
}