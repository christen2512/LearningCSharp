using Advanced.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Controllers;

public class HomeController(DataContext context) : Controller
{
    public IActionResult Index([FromQuery] string selectedCity) =>
        View(new PeopleListViewModel
        {
            People = context.People
                .Include(p => p.Department)
                .Include(p => p.Location),
            Cities = context.Locations.Select(l => l.City).Distinct(),
            SelectedCity = selectedCity
        });
}

public class PeopleListViewModel
{
    public IEnumerable<Person> People { get; set; } = [];
    
    public IEnumerable<string> Cities { get; set; } = [];

    public string SelectedCity { get; set; } = string.Empty;

    public string GetClass(string? city) =>
        SelectedCity == city ? "bg-info text-white" : "";
}