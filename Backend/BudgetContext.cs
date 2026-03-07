    using Microsoft.EntityFrameworkCore;

public class BudgetContext : DbContext
{
    public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
    {
    }

    public DbSet<Backend.Models.Transaction> Transactions { get; set; }
}