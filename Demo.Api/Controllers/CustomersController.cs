using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{

    public CustomersController()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerCreationRequest request)
    {


        return Ok();
    }

    public class CustomerCreationRequest
    {
        public string FirstName { get; set; }
    }
}
