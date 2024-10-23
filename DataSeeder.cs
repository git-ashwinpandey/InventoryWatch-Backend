using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static async Task Initialize(AppDbContext dbContext)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // This will ignore case when deserializing
        };
        // Seed Users
        if (!await dbContext.Users.AnyAsync())
        {
            if (dbContext.Users.Any())
            {
                dbContext.Users.RemoveRange(dbContext.Users); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }

            var usersJson = await File.ReadAllTextAsync("SeedData/users.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersJson, options);
            Console.WriteLine(usersJson);
            if (users != null)
            {
                dbContext.Users.AddRange(users);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed Products
        if (!await dbContext.Products.AnyAsync())
        {
            if (dbContext.Products.Any())
            {
                dbContext.Products.RemoveRange(dbContext.Products); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var productsJson = await File.ReadAllTextAsync("SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsJson, options);
            if (products != null)
            {
                dbContext.Products.AddRange(products);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed Sales
        if (!await dbContext.Sales.AnyAsync())
        {
            if (dbContext.Sales.Any())
            {
                dbContext.Sales.RemoveRange(dbContext.Sales); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var salesJson = await File.ReadAllTextAsync("SeedData/sales.json");
            var sales = JsonSerializer.Deserialize<List<Sale>>(salesJson, options);
            if (sales != null)
            {
                dbContext.Sales.AddRange(sales);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed Purchases
        if (!await dbContext.Purchases.AnyAsync())
        {
            if (dbContext.Purchases.Any())
            {
                dbContext.Purchases.RemoveRange(dbContext.Purchases); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var purchasesJson = await File.ReadAllTextAsync("SeedData/purchases.json");
            var purchases = JsonSerializer.Deserialize<List<Purchase>>(purchasesJson, options);
            if (purchases != null)
            {
                dbContext.Purchases.AddRange(purchases);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed Expenses
        if (!await dbContext.Expenses.AnyAsync())
        {
            if (dbContext.Expenses.Any())
            {
                dbContext.Expenses.RemoveRange(dbContext.Expenses); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var expensesJson = await File.ReadAllTextAsync("SeedData/expenses.json");
            var expenses = JsonSerializer.Deserialize<List<Expense>>(expensesJson, options);
            if (expenses != null)
            {
                dbContext.Expenses.AddRange(expenses);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed ExpenseSummary
        if (!await dbContext.ExpenseSummaries.AnyAsync())
        {
            if (dbContext.ExpenseSummaries.Any())
            {
                dbContext.ExpenseSummaries.RemoveRange(dbContext.ExpenseSummaries); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var expenseSummaryJson = await File.ReadAllTextAsync("SeedData/expenseSummary.json");
            var expenseSummaries = JsonSerializer.Deserialize<List<ExpenseSummary>>(expenseSummaryJson, options);
            if (expenseSummaries != null)
            {
                dbContext.ExpenseSummaries.AddRange(expenseSummaries);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed ExpenseByCategory
        if (!await dbContext.ExpensesByCategory.AnyAsync())
        {
            if (dbContext.ExpensesByCategory.Any())
            {
                dbContext.ExpensesByCategory.RemoveRange(dbContext.ExpensesByCategory); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var expenseByCategoryJson = await File.ReadAllTextAsync("SeedData/expenseByCategory.json");
            var expenseByCategory = JsonSerializer.Deserialize<List<ExpenseByCategory>>(expenseByCategoryJson, options);
            if (expenseByCategory != null)
            {
                dbContext.ExpensesByCategory.AddRange(expenseByCategory);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed SalesSummary
        if (!await dbContext.SalesSummaries.AnyAsync())
        {
            if (dbContext.SalesSummaries.Any())
            {
                dbContext.SalesSummaries.RemoveRange(dbContext.SalesSummaries); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var salesSummaryJson = await File.ReadAllTextAsync("SeedData/salesSummary.json");
            var salesSummaries = JsonSerializer.Deserialize<List<SalesSummary>>(salesSummaryJson, options);
            if (salesSummaries != null)
            {
                dbContext.SalesSummaries.AddRange(salesSummaries);
                await dbContext.SaveChangesAsync();
            }
        }

        // Seed PurchaseSummary
        if (!await dbContext.PurchaseSummaries.AnyAsync())
        {
            if (dbContext.PurchaseSummaries.Any())
            {
                dbContext.PurchaseSummaries.RemoveRange(dbContext.PurchaseSummaries); // Removes all existing users
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            var purchaseSummaryJson = await File.ReadAllTextAsync("SeedData/purchaseSummary.json");
            var purchaseSummaries = JsonSerializer.Deserialize<List<PurchaseSummary>>(purchaseSummaryJson, options);
            if (purchaseSummaries != null)
            {
                dbContext.PurchaseSummaries.AddRange(purchaseSummaries);
                await dbContext.SaveChangesAsync();
            }
        }

        
    }
}
