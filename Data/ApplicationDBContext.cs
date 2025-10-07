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
            entity.ToTable("quotes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Season).HasColumnName("season");
            entity.Property(e => e.Episode).HasColumnName("episode");
            entity.Property(e => e.Character).HasColumnName("character").HasMaxLength(100);
            entity.Property(e => e.Quote).HasColumnName("quote").HasMaxLength(1000);
        });
    }
}