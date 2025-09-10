//Written 9/5 by jvanloon
//By help of Claude AI with some tweaks thereafter
// Is the date class of quotes served up in the API

// Namespace helps organize, could create a ArrestedAPI.Models.SchoolPlay in the same directory
namespace ArrestedAPI.Models;

public class Quotation
{
    public int Id { get; set; }
    public int Season { get; set; } 
    public int Episode { get; set; }
    public string Character { get; set; } 
    public string Quote { get; set; }
}