//Written 9/5 by jvanloon
//By help of Claude AI with some tweaks thereafter
//Quotation Services sets up the methods that perform actions on the Model class Quote

//Pulls in Models Namespace, effectively a link
using ArrestedAPI.Models;

//Declares its own namespace
namespace ArrestedAPI.Services;

//Creates an interface of methods to be implemented by the class
//Duplicative sine the methods are defined below? Likely. 
public interface IQuotationService
{
    Task<IEnumerable<Quotation>> GetAllAsync();
    //? means that the quotation could be nullable. 
    Task<Quotation?> GetByIdAsync(int id);
}

//public class name : interface to be implemented
//In Java the "Implemented" keyword would be used. 
public class QuotationService : IQuotationService
{
    //_ means the variable is private
    private readonly List<Quotation> _quotes = new();
    //got to start somewhere
    private int _nextId = 1;

    //News up the service class with some intial data
    //When it is time, instead of newing up static data, I would imagine this is where the DB connection would be newed-up
    public QuotationService()
    {
        // Seed with some initial data
        //News up a list of new objects 
        _quotes.AddRange(new[]
        {
            new Quotation() { Id = _nextId++, Season = 1, Episode = 2, Character = "Tobias Funke", Quote = "I mean, look at me, I'm an actor."},
            new Quotation() { Id = _nextId++, Season = 1, Episode = 3, Character = "Lucille Bluth", Quote = "I mean, it's one banana Michael. What could it cost? $10?"},
            new Quotation() { Id = _nextId++, Season = 1, Episode = 1, Character = "Lucille Bluth", Quote = "Look what the homosexuals have done to me."}
        });
    }
    
    //task represents an asynchronos thread that retruns a type <IEnumberable> of Quotation Objects
    public Task<IEnumerable<Quotation>> GetAllAsync() // just a naming convention, "return everything from this asynchronos thing" 
    {
        return Task.FromResult(_quotes.AsEnumerable());
    }

    //An asynchronous thread that returns a nullable quotation, aka, may return a quotation or not.
    public Task<Quotation?> GetByIdAsync(int id)
    {
        var quotation = _quotes.FirstOrDefault(q => q.Id == id); // Could be an if, if we were fifth graders
        return Task.FromResult(quotation);
    }

}