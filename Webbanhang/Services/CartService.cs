using System.Text.Json;
using Webbanhang.Models;
using Microsoft.AspNetCore.Http;
namespace Webbanhang.Services;

public interface ICartService
{
    ShoppingCart GetCart();
    void AddToCart(CartItem item);
    void RemoveFromCart(int productId);
    void UpdateQuantity(int productId, int quantity);
    void ClearCart();
    void SaveCart(ShoppingCart cart);
}

public class CartService : ICartService
{
    private readonly ISession _session;
    private const string CART_KEY = "shopping_cart";

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _session = httpContextAccessor.HttpContext?.Session
            ?? throw new InvalidOperationException("Session not available");
    }

    public ShoppingCart GetCart()
    {
        var json = _session.GetString(CART_KEY);
        if (string.IsNullOrEmpty(json))
            return new ShoppingCart();

        return JsonSerializer.Deserialize<ShoppingCart>(json) ?? new ShoppingCart();
    }

    public void AddToCart(CartItem item)
    {
        var cart = GetCart();
        cart.AddItem(item);
        SaveCart(cart);
    }

    public void RemoveFromCart(int productId)
    {
        var cart = GetCart();
        cart.RemoveItem(productId);
        SaveCart(cart);
    }

    public void UpdateQuantity(int productId, int quantity)
    {
        var cart = GetCart();
        cart.UpdateQuantity(productId, quantity);
        SaveCart(cart);
    }

    public void ClearCart()
    {
        _session.Remove(CART_KEY);
    }

    public void SaveCart(ShoppingCart cart)
    {
        var json = JsonSerializer.Serialize(cart);
        _session.SetString(CART_KEY, json);
    }
}