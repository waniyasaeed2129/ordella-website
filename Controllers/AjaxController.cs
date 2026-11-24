using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ordella_deliverable2.Repositories.Interfaces;
namespace Ordella_deliverable2.Controllers;
[Route("ajax")]
public class AjaxController(IShopRepository shops,IProductRepository products,UserManager<IdentityUser> users):Controller
{
 [HttpGet("shops")] public async Task<IActionResult> Shops()=>Json(await shops.GetPublishedAsync());
 [HttpGet("shops/{slug}/products")] public async Task<IActionResult> Products(string slug){var shop=await shops.GetPublishedBySlugAsync(slug);if(shop is null)return NotFound();return Json(await products.GetAvailableByShopAsync(shop.Id));}
 [Authorize(Roles="Seller"), ValidateAntiForgeryToken, HttpPost("products/{id:int}/availability")] public async Task<IActionResult> SetAvailability(int id,[FromBody] AvailabilityRequest request){if(!ModelState.IsValid)return BadRequest(ModelState);var ownerId=users.GetUserId(User)!;var updated=await products.SetAvailabilityAsync(id,ownerId,request.IsAvailable);return updated?Ok(new{success=true,isAvailable=request.IsAvailable}):NotFound();}
 public sealed record AvailabilityRequest(bool IsAvailable);
}
