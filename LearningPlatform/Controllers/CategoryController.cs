using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("[controller]")]
[ApiController]

public class CategoryController : Controller
{
    // GET: CategoryController/Create

    [HttpPost]
    public ActionResult Create()
    {
        return View();
    }

    // POST: CategoryController/Create
    [HttpGet]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // POST: CategoryController/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // POST: CategoryController/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
