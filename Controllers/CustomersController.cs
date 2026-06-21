using CustomerApii.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApii.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private static List<Customer> customers = new List<Customer>
    {
        new Customer { Id = 1, Name = "Anas", Phone = "0790000000" },
        new Customer { Id = 2, Name = "Ahmad", Phone = "0780000000" }
    };
    private static int nextCustomerId = 3;

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        Customer? customer = customers.FirstOrDefault(customer => customer.Id == id);

        if (customer == null)
        {
            return NotFound("Customer not found");
        }

        return Ok(customer);
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] CustomerRequest request)
    {
        Customer customer = new Customer
        {
            Id = nextCustomerId,
            Name = request.Name,
            Phone = request.Phone
        };

        customers.Add(customer);
        nextCustomerId++;

        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer([FromRoute] int id, [FromBody] CustomerRequest request)
    {
        Customer? customerToUpdate = customers.FirstOrDefault(customer => customer.Id == id);

        if (customerToUpdate == null)
        {
            return NotFound("Customer not found");
        }

        customerToUpdate.Name = request.Name;
        customerToUpdate.Phone = request.Phone;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer([FromRoute] int id)
    {
        Customer? customerToDelete = customers.FirstOrDefault(customer => customer.Id == id);

        if (customerToDelete == null)
        {
            return NotFound("Customer not found");
        }

        customers.Remove(customerToDelete);

        return NoContent();
    }

}