//Written 9/5 by jvanloon
//By help of Claude AI with some tweaks thereafter

using Microsoft.AspNetCore.Mvc;
using ArrestedAPI.Models;
using ArrestedAPI.Services;

//maybe I'll build more controllers later.
namespace MyApiWebsite.Controllers;

//Different than conventional routing that may reference a pre-determined path in the startup configuration
//Attribute based routing based directly on Controller Classes
//Will work off the Controller name: QuotationController >> api/Quotation
[ApiController]
[Route("api/[controller]")]
public class QuotationController : ControllerBase
{
    //At newing-up, create a service, which also news up static data.
    private readonly IQuotationService _quotationService;
    //User that service to create a controller with that service
    public QuotationController(IQuotationService quotationService)
    {
        _quotationService = quotationService;
    }
    
    //Response to a parameterless HTTPGET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotations()
    {
        var quotations = await _quotationService.GetAllAsync();
        return Ok(quotations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quotation>> GetProduct(int id)
    {
        var quotation = await _quotationService.GetByIdAsync(id);
        if (quotation == null)
        {
            return NotFound();
        }
        return Ok(quotation);
    }
}