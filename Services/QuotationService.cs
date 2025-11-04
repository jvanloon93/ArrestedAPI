//Written 9/5 by jvanloon
//By help of Claude AI with some tweaks thereafter
//Quotation Services sets up the methods that perform actions on the Model class Quote

//Pulls in Models Namespace, effectively a link

using ArrestedAPI.Data;
using ArrestedAPI.Models;
using Microsoft.EntityFrameworkCore;

//Declares its own namespace
namespace ArrestedAPI.Services;

//Creates an interface of methods to be implemented by the class
//Duplicative sine the methods are defined below? Likely. 
public interface IQuotationService
{
    Task<IEnumerable<Quotation>> GetAllAsync();
    //? means that the quotation could be nullable. 
    Task<Quotation?> GetByIdAsync(int id);
    
    Task<IEnumerable<Quotation>> GetBySeasonAsync (int seasonId);
    
    Task<IEnumerable<Quotation>> GetBySeasonAndEpisodeAsync(int seasonId, int episodeId);
}

//public class name : interface to be implemented
//In Java the "Implemented" keyword would be used. 
public class QuotationService : IQuotationService
{
    //_ means the variable is private
    private readonly List<Quotation> _quotes = new();
    private readonly ApplicationDBContext _context;
    private readonly ILogger<QuotationService> _logger;

    public QuotationService(ApplicationDBContext context, ILogger<QuotationService> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    //task represents an asynchronos thread that retruns a type <IEnumberable> of Quotation Objects
    public async Task<IEnumerable<Quotation>> GetAllAsync() // just a naming convention, "return everything from this asynchronos thing" 
    {
        return await _context.Quotes.OrderBy(q => q.Id).ToListAsync();
    }

    //An asynchronous thread that returns a nullable quotation, aka, may return a quotation or not.
    public async Task<Quotation?> GetByIdAsync(int id)
    {
        return await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id);
    }
    
    public async Task<IEnumerable<Quotation>> GetBySeasonAsync(int seasonId)
    {
        return await _context.Quotes.Where(q => q.Season == seasonId).ToListAsync();
    }

    public async Task<IEnumerable<Quotation>> GetBySeasonAndEpisodeAsync(int seasonId, int episodeId)
    {
        return await _context.Quotes.Where(q => q.Season == seasonId && q.Episode == episodeId).ToListAsync();
    }
}