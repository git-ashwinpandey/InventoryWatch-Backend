using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("/users")]
    public async Task<IActionResult> GetUserData(string? searchString)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            searchString = searchString.ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(searchString));
        }

        var products = await query.ToListAsync();
        return Ok(products);
    }
}
