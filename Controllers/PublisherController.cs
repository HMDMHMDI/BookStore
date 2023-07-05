using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class PublisherController : Controller
{
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {
        _service = service;
    }
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Publisher publisher)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _service.Add(publisher);
        if (!result)
        {
            ModelState.AddModelError("" , "Something wrong while adding!");
            return BadRequest(ModelState);
        }
        TempData["msg"] = "Added Successfully";
        return RedirectToAction("Add");
    }

    public IActionResult Update(int id)
    {
        var record = _service.FindById(id);
        return View(record);
    }

    [HttpPost]
    public IActionResult Update(Publisher publisher)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _service.Update(publisher);
        if (!result)
        {
            ModelState.AddModelError("" , "Something wrong while updating");
            return BadRequest(ModelState);
        }
        TempData["msg"] = "Added Successfully";
        return RedirectToAction("GetAll");
    }

    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        return RedirectToAction("GetAll");
    }

    public IActionResult GetAll()
    {
        var result = _service.GetAll();
        return View(result);
    }
}