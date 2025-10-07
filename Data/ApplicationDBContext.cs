using Microsoft.EntityFrameworkCore;
using ArrestedAPI.Models;

namespace ArrestedAPI.Data;

public class ApplicationDBContext : DbContext 
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }
    public DbSet<Quotation> Quotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Season).IsRequired().HasColumnType("nvarchar(100)");
            entity.Property(e => e.Episode).IsRequired().HasColumnType("nvarchar(100)");
            entity.Property(e => e.Character).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Quote).IsRequired().HasMaxLength(500);
        });
        modelBuilder.Entity<Quotation>().HasData(
            new Quotation()
            {
                Id = 1, Season = 1, Episode = 2, Character = "Tobias Funke", Quote = "I mean, look at me, I'm an actor."
            },
            new Quotation()
            {
                Id = 2, Season = 1, Episode = 3, Character = "Lucille Bluth",
                Quote = "I mean, it's one banana Michael. What could it cost? $10?"
            },
            new Quotation()
            {
                Id = 3, Season = 1, Episode = 1, Character = "Lucille Bluth",
                Quote = "Look what the homosexuals have done to me."
            },
            new Quotation()
            {
                Id = 4, Season = 1, Episode = 1, Character = "Boat Full of Homesexual Protestors",
                Quote = "We're here! We're queer! We want to get married on the ocean!"
            },
            new Quotation()
            {
                Id = 5, Season = 1, Episode = 1, Character = "Lucille Bluth",
                Quote = "Everything they do is so dramaic and flamboyent, it just makes me want to set myself on fire!"
            },
            new Quotation()
            {
                Id = 6, Season = 1, Episode = 1, Character = "Gob Bluth",
                Quote = "Illusion Michael, a trick is something a whore does for money"
            },
            new Quotation()
                { Id = 7, Season = 1, Episode = 1, Character = "Lucille Bluth", Quote = "I don't care for Gob." },
            new Quotation()
            {
                Id = 8, Season = 1, Episode = 1, Character = "Tobias Funkie",
                Quote = "It's good. It's going to be good."
            },
            new Quotation()
            {
                Id = 9, Season = 1, Episode = 1, Character = "Narrator",
                Quote =
                    "Then, mistaking a group of garishly dressed men for pirates, Tobias boarded a van of homosexuals."
            },
            new Quotation()
            {
                Id = 10, Season = 1, Episode = 1, Character = "Tobias",
                Quote =
                    "No, I'm not --I'm not gay. No Lindsey, how many times must we have this -- No. I want to be an actor."
            },
            new Quotation()
            {
                Id = 11, Season = 1, Episode = 1, Character = "George Bluth",
                Quote = "They cannot arrest a husband and wife for the same crime..."
            },
            new Quotation()
            {
                Id = 12, Season = 1, Episode = 1, Character = "Gob Bluth",
                Quote = "*creates smoke and releases a bird* That enough of a reference for you?"
            },
            new Quotation()
            {
                Id = 13, Season = 1, Episode = 1, Character = "Georgde Bluth",
                Quote = "*sitting in jail wearing a durag* I am having the time of my life!"
            }
        );
    }
}