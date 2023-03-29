using Microsoft.AspNetCore.Mvc;
using pastebin_clone_2.models;
using pastebin_clone_2.Services;

namespace pastebin_clone_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PastesController : ControllerBase
{
    private readonly PasteService _pastesService;

    public PastesController(PasteService pastesService)
    {
        _pastesService = pastesService;
    }

    [HttpGet]
    public async Task<List<Paste>> Get() =>
        await _pastesService.GetAsync();
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Paste>> Get(string id)
    {
        var Paste = await _pastesService.GetAsync(id);

        if (Paste is null)
        {
            return NotFound();
        }

        return Paste;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Post(Paste newPaste)
    {
        await _pastesService.CreateAsync(newPaste);

        return CreatedAtAction(nameof(Get), new { id = newPaste.Id }, newPaste);
    }
    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Paste updatedPaste)
    {
        var Paste = await _pastesService.GetAsync(id);

        if (Paste is null)
        {
            return NotFound();
        }

        updatedPaste.Id = Paste.Id;

        await _pastesService.UpdateAsync(id, updatedPaste);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Paste = await _pastesService.GetAsync(id);

        if (Paste is null)
        {
            return NotFound();
        }

        await _pastesService.RemoveAsync(Paste.Id);

        return NoContent();
    }
}