using System.ComponentModel.DataAnnotations;

namespace Webbanhang.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required, StringLength(50)]
    public string Status { get; set; } = "Pending";  // Pending, Shipped, Delivered, Cancelled

    public decimal TotalAmount { get; set; }

    public string? ShippingAddress { get; set; }
    public string? Notes { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

public class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal Total => Quantity * Price;
}