using Microsoft.EntityFrameworkCore;
using MyExpenseTracker.Model;

namespace MyExpenseTracker.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<ExpenseItem> ExpenseItems { get; set; }
    }
}
