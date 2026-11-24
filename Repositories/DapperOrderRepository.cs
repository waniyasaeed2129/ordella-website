using Dapper;
using Ordella_deliverable2.Models;
using Ordella_deliverable2.Repositories.Interfaces;
namespace Ordella_deliverable2.Repositories;
public sealed class DapperOrderRepository(DapperConnectionFactory factory) : IOrderRepository
{
 public async Task<IEnumerable<CustomerOrder>> GetRecentByShopOwnerAsync(string ownerId,int take=10){using var db=factory.Create();return await db.QueryAsync<CustomerOrder>("SELECT TOP (@take) o.Id,o.OrderNumber,o.CustomerName,o.CustomerEmail,o.CustomerPhone,o.Notes,o.Status,o.Total,o.CreatedAt,o.ShopId FROM Orders o INNER JOIN Shops s ON o.ShopId=s.Id WHERE s.OwnerId=@ownerId ORDER BY o.CreatedAt DESC",new{ownerId,take});}
}
