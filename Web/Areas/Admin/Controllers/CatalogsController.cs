using Azure;
using Business.Features.Catalogs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CatalogsController(ICatalogsService catalogsService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var list = await catalogsService.GetCatalogListAsync();
        return View(list);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Catalog catalog)
    {
        if (ModelState.IsValid)
        {
            catalog.DateCreated = DateTime.UtcNow;
            catalog.UserId = UserId!.Value;
            var result = await catalogsService.CreateCatalogAsync(catalog);
            if (result < 0)
            {
                ModelState.AddModelError("", "Bu katalog zaten oluşturulmuş");
                return View(catalog);
            }
            return RedirectToAction(nameof(Index));
        }
        return View(catalog);
    }
}
