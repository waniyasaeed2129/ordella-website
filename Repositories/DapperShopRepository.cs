using Dapper;
using Ordella_deliverable2.Models;
using Ordella_deliverable2.Repositories.Interfaces;
namespace Ordella_deliverable2.Repositories;
public sealed class DapperShopRepository(DapperConnectionFactory factory) : IShopRepository
{
 public async Task<IEnumerable<Shop>> GetPublishedAsync(){using var db=factory.Create();return await db.QueryAsync<Shop>("SELECT Id,Name,Slug,Description,ContactEmail,BannerUrl,OwnerId,IsPublished,CreatedAt FROM Shops WHERE IsPublished=1 ORDER BY Name");}
 public async Task<Shop?> GetPublishedBySlugAsync(string slug){using var db=factory.Create();return await db.QueryFirstOrDefaultAsync<Shop>("SELECT Id,Name,Slug,Description,ContactEmail,BannerUrl,OwnerId,IsPublished,CreatedAt FROM Shops WHERE Slug=@slug AND IsPublished=1",new{slug});}
}
