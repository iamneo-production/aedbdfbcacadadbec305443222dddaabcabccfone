using Microsoft.AspNetCore.Mvc;
using dotnetwebapiAddCustomer.Models;

namespace dotnetwebapiAddCustomer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerDbContext customerDbContext;
    public CustomerController(CustomerDbContext _customerDbContext)
    {
        customerDbContext = _customerDbContext;
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer(Customer customer)
    {
        if (!ModelState.IsValid)
    {
        return BadRequest(ModelState); // Return detailed validation errors
    }
        await customerDbContext.Customers.AddAsync(customer);
        await customerDbContext.SaveChangesAsync();
        return Ok();
    }
}