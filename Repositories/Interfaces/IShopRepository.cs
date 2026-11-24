using Ordella_deliverable2.Models;
namespace Ordella_deliverable2.Repositories.Interfaces;
public interface IShopRepository
{
 Task<IEnumerable<Shop>> GetPublishedAsync();
 Task<Shop?> GetPublishedBySlugAsync(string slug);
}
