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
        var data = await productService.GetAllAsync();
        return View(data);
    }


    public async Task<IActionResult> Create()
    {
        var categories = await categoryService.GetAllAsync();

        ViewBag.Categories = categories.Select(c =>
            new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(ProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            var categories = await categoryService.GetAllAsync();

            ViewBag.Categories = categories.Select(c =>
                new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                }).ToList();

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

        var categories = await categoryService.GetAllAsync();

        ViewBag.Categories = categories.Select(c =>
            new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();

        return View(product);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(ProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            var categories = await categoryService.GetAllAsync();

            ViewBag.Categories = categories.Select(c =>
                new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                }).ToList();

            return View(dto);
        }

        await productService.UpdateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

}