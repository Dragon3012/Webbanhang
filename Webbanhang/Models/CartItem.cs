namespace Webbanhang.Models;

public class CartItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public decimal Total => Price * Quantity;
}

public class ShoppingCart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public int TotalItems => Items.Sum(x => x.Quantity);
    public decimal TotalPrice => Items.Sum(x => x.Total);

    public void AddItem(CartItem item)
    {
        var existing = Items.FirstOrDefault(x => x.ProductId == item.ProductId);
        if (existing != null)
            existing.Quantity += item.Quantity;
        else
            Items.Add(item);
    }

    public void RemoveItem(int productId) => Items.RemoveAll(x => x.ProductId == productId);

    public void UpdateQuantity(int productId, int quantity)
    {
        var item = Items.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
            item.Quantity = quantity > 0 ? quantity : 1;
    }

    public void Clear() => Items.Clear();
}