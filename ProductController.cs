using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("/products")]
    public async Task<IActionResult> GetProductData(string? searchString)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            searchString = searchString.ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(searchString));
        }

        var products = await query.ToListAsync();
        return Ok(products);
    }

    [HttpPost("/products")]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Product data is required.");
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
}
