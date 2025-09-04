using ArrestedAPI.Models;

namespace ArrestedAPI.Services;

public interface IQuotationService
{
    Task<IEnumerable<Quotation>> GetAllAsync();
    Task<Quotation?> GetByIdAsync(int id);
}

public class QuotationService : IQuotationService
{
    private readonly List<Quotation> _quotes = new();
    private int _nextId = 1;

    public QuotationService()
    {
        // Seed with some initial data
        _quotes.AddRange(new[]
        {
            new Quotation() { Id = _nextId++, Season = 1, Episode = 2, Character = "Tobias Funke", Quote = "I mean, look at me, I'm an actor."},
            new Quotation() { Id = _nextId++, Season = 1, Episode = 3, Character = "Lucille Bluth", Quote = "I mean, it's one banana Michael. What could it cost? $10?"},
            new Quotation() { Id = _nextId++, Season = 1, Episode = 1, Character = "Lucille Bluth", Quote = "Look what the homosexuals have done to me."}
        });
    }

    public Task<IEnumerable<Quotation>> GetAllAsync()
    {
        return Task.FromResult(_quotes.AsEnumerable());
    }

    public Task<Quotation?> GetByIdAsync(int id)
    {
        var quotation = _quotes.FirstOrDefault(q => q.Id == id);
        return Task.FromResult(quotation);
    }

}