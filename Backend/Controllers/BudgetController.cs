using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

// Controller - budget tracking + location
[ApiController] 
[Route("api/[controller]")]

public class BudgetController : ControllerBase
{
    // Notes - while we don't have a database, we will use a static list to store our transactions in memory. This is just for demonstration purposes and should not be used in production.
    //private static List<Transaction> _transactions = new List<Transaction>();

    private readonly BudgetContext _context;

    // Itt a DI: "Befecskendezzük" az adatbázist
    public BudgetController(BudgetContext context)
    {
        _context = context;
    }

    // Show all transactions (GET)
    [HttpGet]
    public List<Backend.Models.Transaction> Get()
    {
        return _context.Transactions.ToList();
    }


    // Add a new transaction (POST)
    [HttpPost]
    public IActionResult Post(Backend.Models.Transaction newItem)
    {
        _context.Transactions.Add(newItem);
        _context.SaveChanges();
        return Ok();;
    }
}