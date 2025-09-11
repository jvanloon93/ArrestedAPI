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
            new Quotation() { Id = 1, Season = 1, Episode = 2, Character = "Tobias Funke", Quote = "I mean, look at me, I'm an actor."},
            new Quotation() { Id = 2, Season = 1, Episode = 3, Character = "Lucille Bluth", Quote = "I mean, it's one banana Michael. What could it cost? $10?"},
            new Quotation() { Id = 3, Season = 1, Episode = 1, Character = "Lucille Bluth", Quote = "Look what the homosexuals have done to me."},
            new Quotation() { Id = 4, Season = 1, Episode = 1, Character = "Boat Full of Homesexual Protestors", Quote = "We're here! We're queer! We want to get married on the ocean!"},
            new Quotation() { Id = 5, Season = 1, Episode = 1, Character = "Lucille Bluth", Quote = "Everything they do is so dramaic and flamboyent, it just makes me want to set myself on fire!"},
            new Quotation() { Id = 6, Season = 1, Episode = 1, Character = "Gob Bluth", Quote = "Illusion Michael, a trick is something a whore does for money"},
            new Quotation() { Id = 7, Season = 1, Episode = 1, Character = "Lucille Bluth", Quote = "I don't care for Gob."},
            new Quotation() { Id = 8, Season = 1, Episode = 1, Character = "Tobias Funkie", Quote = "It's good. It's going to be good."},
            new Quotation() { Id = 9, Season = 1, Episode = 1, Character = "Narrator", Quote = "Then, mistaking a group of garishly dressed men for pirates, Tobias boarded a van of homosexuals."},
            new Quotation() { Id = 10, Season = 1, Episode = 1, Character = "Tobias", Quote = "No, I'm not --I'm not gay. No Lindsey, how many times must we have this -- No. I want to be an actor."},
            new Quotation() { Id = 11, Season = 1, Episode = 1, Character = "George Bluth", Quote = "They cannot arrest a husband and wife for the same crime..."},
            new Quotation() { Id = 12, Season = 1, Episode = 1, Character = "Gob Bluth", Quote = "*creates smoke and releases a bird* That enough of a reference for you?"},
            new Quotation() { Id = 13, Season = 1, Episode = 1, Character = "Georgde Bluth", Quote = "*sitting in jail wearing a durag* I am having the time of my life!"}
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