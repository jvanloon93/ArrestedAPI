namespace ArrestedAPI.Models;

public class Quotation
{
    public int Id { get; set; }
    public int Season { get; set; } 
    public int Episode { get; set; }
    public string Character { get; set; } 
    public string Quote { get; set; }
}