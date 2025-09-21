using Demo.Application.Features.Customers.CreateCustomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ISender _sender;


    public CustomersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
    {
        var response = await _sender.Send(request);

        return Ok(response);
    }

    //public class CustomerCreationRequest
    //{
    //    public string FirstName { get; set; }
    //}
}
