using Advanced.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Pages;

public class Index(DataContext context) : PageModel
{
    public IEnumerable<Person> People { get; set; } = [];
    public IEnumerable<string> Cities { get; set; } = [];

    [FromQuery] public string SelectedCity { get; set; } = string.Empty;
    
    public void OnGet()
    {
        People = context.People
            .Include(p => p.Department)
            .Include(p => p.Location);
        Cities = context.Locations.Select(l => l.City).Distinct();
    }

    public string GetClass(string? city) =>
        SelectedCity == city ? "bg-info text-white" : "";

}