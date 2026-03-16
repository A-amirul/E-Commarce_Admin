using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Web.Controllers;

public class CategoryController(ICategoryService service) : Controller
{

    public async Task<IActionResult> Index()
    {
        var data = await service.GetAllAsync();
        return View(data);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await service.CreateAsync(dto);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int id)
    {
        var category = await service.GetAsync(id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await service.UpdateAsync(dto);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int id)
    {
        var category = await service.GetAsync(id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}