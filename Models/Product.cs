using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ordella_deliverable2.Models;
public class Product
{
    public int Id { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = "";
    [StringLength(600)] public string? Description { get; set; }
    [Range(0.01, 10000000)] public decimal Price { get; set; }
    [StringLength(300)] public string? ImageUrl { get; set; }
    [StringLength(60)] public string? Category { get; set; }
    public bool IsAvailable { get; set; } = true;
    public int ShopId { get; set; }
    public Shop? Shop { get; set; }
}
