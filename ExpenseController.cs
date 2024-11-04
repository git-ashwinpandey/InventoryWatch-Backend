using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExpenseController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("/expenses")]
    public async Task<IActionResult> GetExpenseData()
    {
       
        var expensesByCategory = await _context.ExpensesByCategory
                    .OrderByDescending(e => e.Date)
                    .Select(e => new
                    {
                        e.ExpenseByCategoryId,
                        e.ExpenseSummaryId,
                        e.Date,
                        e.Category,
                        Amount = e.Amount.ToString() // Convert long to string
                    })
                    .ToListAsync();


        return Ok(expensesByCategory);
    }
}
