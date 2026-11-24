using Dapper;
using Ordella_deliverable2.Models;
using Ordella_deliverable2.Repositories.Interfaces;
namespace Ordella_deliverable2.Repositories;
public sealed class DapperProductRepository(DapperConnectionFactory factory) : IProductRepository
{
 public async Task<IEnumerable<Product>> GetAvailableByShopAsync(int shopId){using var db=factory.Create();return await db.QueryAsync<Product>("SELECT Id,Name,Description,Price,ImageUrl,Category,IsAvailable,ShopId FROM Products WHERE ShopId=@shopId AND IsAvailable=1 ORDER BY Name",new{shopId});}
 public async Task<bool> SetAvailabilityAsync(int productId,string ownerId,bool isAvailable){using var db=factory.Create();var rows=await db.ExecuteAsync("UPDATE p SET IsAvailable=@isAvailable FROM Products p INNER JOIN Shops s ON p.ShopId=s.Id WHERE p.Id=@productId AND s.OwnerId=@ownerId",new{productId,ownerId,isAvailable});return rows==1;}
}
