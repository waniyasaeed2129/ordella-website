using Ordella_deliverable2.Models;
namespace Ordella_deliverable2.Repositories.Interfaces;
public interface IProductRepository
{
 Task<IEnumerable<Product>> GetAvailableByShopAsync(int shopId);
 Task<bool> SetAvailabilityAsync(int productId, string ownerId, bool isAvailable);
}
