using Ecommerce.Application.Interfaces;
using Ecommerce.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Admin.Web.Controllers;

public class ProductController(
    IProductService productService,
    ICategoryService categoryService) : Controller
{

    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllAsync();
        var categories = await categoryService.GetAllAsync();

        ViewBag.Categories = categories
            .ToDictionary(c => c.CategoryID, c => c.CategoryName);

        return View(products);
    }

    public async Task<IActionResult> Create()
    {
        await LoadCategories();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadCategories();
            return View(dto);
        }

        await productService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await productService.GetAsync(id);

        if (product == null)
            return NotFound();

        await LoadCategories();
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadCategories();
            return View(dto);
        }

        await productService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await productService.GetAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int ProductID)
    {
        await productService.DeleteAsync(ProductID);
        return RedirectToAction(nameof(Index));
    }

    // 🔹 Helper method to avoid repetition
    private async Task LoadCategories()
    {
        var categories = await categoryService.GetAllAsync();

        ViewBag.Categories = categories.Select(c =>
            new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();
    }
}