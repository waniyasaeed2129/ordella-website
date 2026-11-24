using Microsoft.Data.SqlClient;
using System.Data;
namespace Ordella_deliverable2.Repositories;
public sealed class DapperConnectionFactory
{
 private readonly string _connectionString;
 public DapperConnectionFactory(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection is missing.");
 public IDbConnection Create() => new SqlConnection(_connectionString);
}
