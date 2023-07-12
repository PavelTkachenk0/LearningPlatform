using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Route("[controller]")]
[ApiController]
public class MediaTypeController : Controller
{
    // POST: MediaTypeController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
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

    [HttpGet]
    // GET: MediaTypeController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: MediaTypeController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
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

    [HttpGet]
    // GET: MediaTypeController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: MediaTypeController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
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
