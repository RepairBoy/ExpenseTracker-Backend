using Microsoft.AspNetCore.Mvc;
using MyExpenseTracker.Data;
using MyExpenseTracker.Model;

namespace MyExpenseTracker.Controllers
{
    [Route("api/[controller]")]     //to provide the route of the api
    [ApiController]
    public class ExpenseItemController:ControllerBase
    {
        private ApiDbContext _dbContext;
        public ExpenseItemController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]       
        public IEnumerable<ExpenseItem> GetExpenses()
        {
            return _dbContext.ExpenseItems;
        }

        [HttpPost]
        public void AddExpense([FromBody] ExpenseItem expense)
        { 
            _dbContext.ExpenseItems.Add(expense);
            _dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            ExpenseItem expenseToDelete = _dbContext.ExpenseItems.FirstOrDefault(t => t.Id == id);
            if (expenseToDelete != null)
            {
                _dbContext.ExpenseItems.Remove(expenseToDelete);
                _dbContext.SaveChanges();
                return Ok(new { message = $"Item with ID {id} is deleted succesfully" });
            }
            else { return NotFound(new { message = $"Item with ID {id} not found." }); }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, [FromBody] ExpenseItem expenseItem)
        {
            ExpenseItem expenseToUpdate = _dbContext.ExpenseItems.FirstOrDefault(t => t.Id == id);
            if (expenseToUpdate != null)
            {
                expenseToUpdate.Name = expenseItem.Name;
                expenseToUpdate.Description = expenseItem.Description;
                expenseToUpdate.Amount = expenseItem.Amount;
                _dbContext.SaveChanges();
                return Ok(new { message = $"Item with ID {id} is updated succesfully" });
            }
            else { return NotFound(new { message = $"Item with ID {id} not found." }); }
        }
        [HttpGet("{id}")]
        public IActionResult GetExpense(int id)
        {
            ExpenseItem expenseToGet = _dbContext.ExpenseItems.FirstOrDefault(t => t.Id == id);
            if (expenseToGet != null)
            {
                return Ok(expenseToGet);
            }
            else { return NotFound(new { message = $"Item with ID {id} not found." }); }

        }
    }
}
