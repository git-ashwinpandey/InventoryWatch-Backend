using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class User
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Product
{
    public string ProductId { get; set; } // Primary key
    public string Name { get; set; }
    public float Price { get; set; }
    public float? Rating { get; set; }
    public int StockQuantity { get; set; }
    // Make navigation properties virtual and nullable
    [JsonIgnore]
    public virtual ICollection<Sale>? Sales { get; set; }
    [JsonIgnore]
    public virtual ICollection<Purchase>? Purchases { get; set; }
}

public class Sale
{
    public string SaleId { get; set; } // Primary key
    public string ProductId { get; set; } // Foreign key
    public DateTime Timestamp { get; set; }
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }
    public float TotalAmount { get; set; }

    public Product Product { get; set; }
}

public class Purchase
{
    public string PurchaseId { get; set; } // Primary key
    public string ProductId { get; set; } // Foreign key
    public DateTime Timestamp { get; set; }
    public int Quantity { get; set; }
    public float UnitCost { get; set; }
    public float TotalCost { get; set; }

    public Product Product { get; set; }
}

public class Expense
{
    public string ExpenseId { get; set; } // Primary key
    public string Category { get; set; }
    public float Amount { get; set; }
    public DateTime Timestamp { get; set; }
}

public class SalesSummary
{
    public string SalesSummaryId { get; set; } // Primary key
    public float TotalValue { get; set; }
    public float? ChangePercentage { get; set; }
    public DateTime Date { get; set; }
}

public class PurchaseSummary
{
    public string PurchaseSummaryId { get; set; } // Primary key
    public float TotalPurchased { get; set; }
    public float? ChangePercentage { get; set; }
    public DateTime Date { get; set; }
}

public class ExpenseSummary
{
    public string ExpenseSummaryId { get; set; } // Primary key
    public float TotalExpenses { get; set; }
    public DateTime Date { get; set; }
    public ICollection<ExpenseByCategory> ExpenseByCategory { get; set; }
}

public class ExpenseByCategory
{
    public string ExpenseByCategoryId { get; set; } // Primary key
    public string ExpenseSummaryId { get; set; } // Foreign key
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public long Amount { get; set; }
    

    public ExpenseSummary ExpenseSummary { get; set; }
}
