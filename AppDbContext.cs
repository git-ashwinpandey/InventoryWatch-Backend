using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<SalesSummary> SalesSummaries { get; set; }
    public DbSet<PurchaseSummary> PurchaseSummaries { get; set; }
    public DbSet<ExpenseSummary> ExpenseSummaries { get; set; }
    public DbSet<ExpenseByCategory> ExpensesByCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>()
            .HasOne(s => s.Product)
            .WithMany(p => p.Sales)
            .HasForeignKey(s => s.ProductId);

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Product)
            .WithMany(p => p.Purchases)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<ExpenseByCategory>()
            .HasOne(e => e.ExpenseSummary)
            .WithMany(es => es.ExpenseByCategory)
            .HasForeignKey(e => e.ExpenseSummaryId);
    }
}
