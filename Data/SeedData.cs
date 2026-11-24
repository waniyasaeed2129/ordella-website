using Microsoft.AspNetCore.Identity;
namespace Ordella_deliverable2.Data;
public static class SeedData
{
 public static async Task InitializeAsync(IServiceProvider services){using var scope=services.CreateScope();var roles=scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();foreach(var role in new[]{"Seller","Customer"})if(!await roles.RoleExistsAsync(role))await roles.CreateAsync(new IdentityRole(role));}
}
