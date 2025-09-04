using Microsoft.AspNetCore.Mvc;
using ArrestedAPI.Models;
using ArrestedAPI.Services;

namespace MyApiWebsite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotationController : ControllerBase
{
    private readonly IQuotationService _quotationService;

    public QuotationController(IQuotationService productService)
    {
        _quotationService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotations()
    {
        var products = await _quotationService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quotation>> GetProduct(int id)
    {
        var product = await _quotationService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}