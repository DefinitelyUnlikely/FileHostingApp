using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("folder")]
public class FolderController(IFolderService folderService) : ControllerBase
{

    [HttpPost()]
    public async Task<IActionResult> CreateFolder([FromBody] CreateFolderRequest request)
    {
        try
        {
            return Ok();
        }
        catch (NoChangesSavedException)
        {
            return StatusCode(500);
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpGet("{folderId}")]
    public async Task<IActionResult> GetFolder(string folderId)
    {
        try
        {
            return Ok();
        }
        catch (EmptyReturnException)
        {
            return NotFound("No folder with that Id was found");
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpPatch("{folderId}")]
    public async Task<IActionResult> UpdateFolder([FromBody] UpdateFolderRequest request, string folderId)
    {
        try
        {
            return Ok();
        }
        catch (EmptyReturnException)
        {
            return NotFound("No folder with that Id was found");
        }
        catch (NoChangesSavedException)
        {
            return StatusCode(500);
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpDelete("{folderId}")]
    public async Task<IActionResult> DeleteFolder(string folderId)
    {
        try
        {
            return Ok();
        }
        catch (EmptyReturnException)
        {
            return NotFound("No folder with that Id was found");
        }
        catch (NoChangesSavedException)
        {
            return StatusCode(500);
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }
}