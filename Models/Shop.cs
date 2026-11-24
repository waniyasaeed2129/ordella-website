using System.ComponentModel.DataAnnotations;

namespace Ordella_deliverable2.Models;
public class Shop
{
    public int Id { get; set; }
    [Required, StringLength(80)] public string Name { get; set; } = "";
    [Required, StringLength(80)] public string Slug { get; set; } = "";
    [StringLength(500)] public string? Description { get; set; }
    [StringLength(120)] public string? ContactEmail { get; set; }
    [StringLength(300)] public string? BannerUrl { get; set; }
    [Required] public string OwnerId { get; set; } = "";
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Product> Products { get; set; } = new();
}
