using System.ComponentModel.DataAnnotations;
namespace Ordella_deliverable2.Models;
public class CustomerOrder
{
    public int Id { get; set; }
    [Required] public string OrderNumber { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
    [Required, StringLength(100)] public string CustomerName { get; set; } = "";
    [Required, EmailAddress] public string CustomerEmail { get; set; } = "";
    [Required, StringLength(30)] public string CustomerPhone { get; set; } = "";
    [StringLength(500)] public string? Notes { get; set; }
    [Required] public string Status { get; set; } = "Received";
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int ShopId { get; set; }
    public Shop? Shop { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}
