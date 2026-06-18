using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbanhang.Models;
using Webbanhang.Repositories;

namespace Webbanhang.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]      // Chỉ Admin được vào
public class DashboardController : Controller
{
    private readonly IProductRepository _productRepository;

    public DashboardController(IProductRepository productRepository)
        => _productRepository = productRepository;

    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAllAsync();
        ViewBag.TotalProducts = products.Count();
        return View();
    }
}