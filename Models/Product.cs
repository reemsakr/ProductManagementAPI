using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI;

public class Product
{
    [Key]
    public int productId { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Product name is required and must be at least 3 characters long")]
    public string? name { get; set; }

    [MaxLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
    public string? description { get; set; }

    [Required]
    [Range(0.01, 1000, ErrorMessage = "Product price is required and must be at least 0.01.")]
    public decimal price { get; set; }

    [Required]
    [Range(0, 1000, ErrorMessage = "Stock quantity is required and must be a non - negative value.")]
    public int stockQuantity { get; set; }
    public DateTime createdDate { get; set; }
}
