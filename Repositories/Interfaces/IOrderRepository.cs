using Ordella_deliverable2.Models;
namespace Ordella_deliverable2.Repositories.Interfaces;
public interface IOrderRepository
{
 Task<IEnumerable<CustomerOrder>> GetRecentByShopOwnerAsync(string ownerId, int take = 10);
}
