using GlassesApi.Models;
using GlassesApi.services;
using Microsoft.AspNetCore.Mvc;

namespace GlassesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlassesController : ControllerBase
{
    public GlassesController()
    {


    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Glasses>> GetAll() =>
        GlassesService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Glasses> Get(int id)
    {
        var glasses = GlassesService.Get(id);

        if (glasses == null)
            return NotFound();

        return glasses;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Glasses glasses)
    {
        GlassesService.Add(glasses);
        return CreatedAtAction(nameof(Get), new { id = glasses.Id }, glasses);
        // This code will save the glasses and return a result
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Glasses glasses)
    {
        if (id != glasses.Id)
            return BadRequest();

        var existingGlasses = GlassesService.Get(id);
        if (existingGlasses is null)
            return NotFound();

        GlassesService.Update(glasses);

        return NoContent();
        // This code will update the glasses and return a result
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var glasses = GlassesService.Get(id);

        if (glasses is null)
            return NotFound();

        GlassesService.Delete(id);

        return NoContent();
        // This code will delete the glasses and return a result
    }
}