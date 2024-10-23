using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("/dashboard")]
    public async Task<IActionResult> GetDashboardData()
    {
        var popularProducts = await _context.Products
                                 .OrderByDescending(p => p.StockQuantity)
                                 .Take(15)
                                 .ToListAsync();

        var salesSummary = await _context.SalesSummaries
                           .OrderByDescending(s => s.Date)
                           .Take(5)
                           .ToListAsync();

        var purchaseSummary = await _context.PurchaseSummaries
                              .OrderByDescending(p => p.Date)
                              .Take(5)
                              .ToListAsync();

        var expenseSummary = await _context.ExpenseSummaries
                             .OrderByDescending(e => e.Date)
                             .Take(5)
                             .ToListAsync();

        var expensesByCategory = await _context.ExpensesByCategory
                    .OrderByDescending(e => e.Date)
                    .Take(5)
                    .Select(e => new
                    {
                        e.ExpenseByCategoryId,
                        e.ExpenseSummaryId,
                        e.Date,
                        e.Category,
                        Amount = e.Amount.ToString() // Convert long to string
                    })
                    .ToListAsync();


        return Ok(new
        {
            popularProducts,
            salesSummary,
            purchaseSummary,
            expenseSummary,
            expensesByCategory
        });
    }
}
