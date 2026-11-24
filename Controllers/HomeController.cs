using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using Ordella_deliverable2.Data;
namespace Ordella_deliverable2.Controllers;
public class HomeController:Controller
{private readonly ApplicationDbContext db;public HomeController(ApplicationDbContext d){db=d;}public IActionResult Index()=>View();public IActionResult Privacy()=>View();public async Task<IActionResult> Store(string slug){var shop=await db.Shops.Include(s=>s.Products).FirstOrDefaultAsync(s=>s.Slug==slug&&s.IsPublished);if(shop==null)return NotFound();return View(shop);}public IActionResult Error()=>View();}
