using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class AuthorController : Controller
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Author author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _service.Add(author);
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
    public IActionResult Update(Author author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _service.Update(author);
        if (!result)
        {
            ModelState.AddModelError("" , "Something wrong while updating!");
            return BadRequest(ModelState);
        }
        TempData["msg"] = "Added Successfully";
        return RedirectToAction("GetAll");
    }

    public IActionResult Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _service.Delete(id);
        return RedirectToAction("GetAll");
    }

    public IActionResult GetAll()
    {
        var data = _service.GetAll();
        return View(data);
    }
}