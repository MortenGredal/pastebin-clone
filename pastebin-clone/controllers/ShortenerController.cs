using Microsoft.AspNetCore.Mvc;
using pastebin_clone_2.services;

namespace pastebin_clone_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShortenerController : ControllerBase
{
    private readonly IShortenerService _iShortenerService;

    public ShortenerController(IShortenerService service)
    {
        _iShortenerService = service;
    }
    
    
    [HttpGet("/shorten")]
    
    public Task<ActionResult<String>> Shorten(int id)
    {
        var shortened = _iShortenerService.GenerateShortString(id);

        return Task.FromResult<ActionResult<string>>(shortened);
    }    
    
    [HttpGet]
    public Task<ActionResult<int>> Shorten(string shortString)
    {
        var origin = _iShortenerService.RestoreSeedFromString(shortString);

        return Task.FromResult<ActionResult<int>>(origin);
    }
}