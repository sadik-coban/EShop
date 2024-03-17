using Business.Features.Catalogs;
using Business.Features.Catalogs.Enums;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CatalogsController(ICatalogsService catalogsService) : BaseController
{
    public async Task<IActionResult> Index(int? pageNumber, int? pageSize,string? keywords)
    {
        IEnumerable<Catalog> list;
        if(pageNumber == null || pageSize == null)
        {
            list = await catalogsService.GetCatalogListAsync(keywords,orderBy: OrderByCatalog.DateAscending);
        }
        else
        {
            list = await catalogsService.GetCatalogListAsync(keywords,orderBy: OrderByCatalog.DateAscending, pageNumber: pageNumber!.Value, pageSize: pageSize!.Value);
        }
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
