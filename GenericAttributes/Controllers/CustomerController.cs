using GenericAttributes.Attributes;
using GenericAttributes.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GenericAttributes.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    // [ServiceFilter(typeof(ResponseTimeFilter))]
    [GenericServiceFilter<ResponseTimeFilter>]
    public ObjectResult Get()
    {
        return Ok(new Customer(1, "Sanjay Sahani"));
    }
}

record Customer(int Id, string Name);