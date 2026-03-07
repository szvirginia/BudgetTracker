using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

// Controller - budget tracking + location
[ApiController] 
[Route("api/[controller]")]

public class BudgetController : ControllerBase
{
    // Notes - while we don't have a database, we will use a static list to store our transactions in memory. This is just for demonstration purposes and should not be used in production.
    private static List<Transaction> _transactions = new List<Transaction>();


    // Show all transactions (GET)
    [HttpGet]
    public ActionResult<List<Transaction>> GetAllItems()
    {
        return Ok(_transactions);
    }


    // Add a new transaction (POST)
    [HttpPost]
    public ActionResult AddNewItem(Transaction newItem)
    {
        // New item
        newItem.Id = _transactions.Count + 1;
        _transactions.Add(newItem);
        return Ok(newItem); 
    }
}