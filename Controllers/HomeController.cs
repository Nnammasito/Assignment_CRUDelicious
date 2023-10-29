using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_CRUDelicious.Models;

namespace Assignment_CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dishe> Dishes = _context.Dishes.ToList();
        return View("Index", Dishes);
    }
    [HttpGet("dishes/new")]
    public IActionResult Dishes()
    {
        return View("Dishes");
    }
    [HttpPost("dishes/create")]
    public RedirectToActionResult CreateDishes(Dishe NewDishe)
    {
        _context.Dishes.Add(NewDishe);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet("dishes/{id}")]
    public IActionResult PerfilDishes(int id)
    {
        Dishe? dishe = _context.Dishes.FirstOrDefault(d => d.DisheId == id);
        return View("PerfilDishes", dishe);
    }
    [HttpGet("dishes/{id}/edit")]
    public IActionResult EditDishes(int id)
    {
        Dishe? OldDishe = _context.Dishes.SingleOrDefault(i => i.DisheId == id);
        return View(OldDishe);
    }
    [HttpPost("dishes/{id}/update")]
    public IActionResult UpdateDishes(int id, Dishe EditDishe)
    {
        Dishe? OldDishe = _context.Dishes.FirstOrDefault(i => i.DisheId == id);
        if(ModelState.IsValid)
        {
            OldDishe.Name = EditDishe.Name;
            OldDishe.Chef = EditDishe.Chef;
            OldDishe.Calories =  EditDishe.Calories;
            OldDishe.Tastiness = EditDishe.Tastiness;
            OldDishe.Description = EditDishe.Description;
            OldDishe.UpdatedAt = DateTime.Now;
            _context.Dishes.Update(OldDishe);
            _context.SaveChanges();
            return RedirectToAction("PerfilDishes");
        }
        else
        {
            return View("EditDishes", OldDishe);
        }
    }
    [HttpPost("dishes/{id}/remove")]
    public RedirectToActionResult RemoveDishe(int id)
    {
        Dishe? DeleteDishe = _context.Dishes.SingleOrDefault(i => i.DisheId == id);
        _context.Dishes.Remove(DeleteDishe);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
