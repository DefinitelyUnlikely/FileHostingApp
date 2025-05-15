using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FolderController(IFolderService folderService) : ControllerBase
{

    [Authorize(Roles = "User,Admin")]
    [HttpPost()]
    public async Task<IActionResult> CreateFolder([FromBody] CreateFolderRequest request)
    {
        try
        {
            await folderService.CreateAsync(request);
            return Created();
        }
        catch (NoChangesSavedException)
        {
            return StatusCode(500);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
        {
            return BadRequest("Database did not update and folder was not added: " + e.Message);
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpGet("{folderId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetFolder(Guid folderId)
    {
        try
        {
            var response = await folderService.GetAsync(folderId);
            return Ok(response);
        }
        catch (EmptyReturnException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpGet("user/{userId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetFoldersByUser(string userId)
    {
        try
        {
            var response = await folderService.GetAllUserFoldersAsync(userId);
            return Ok(response);
        }
        catch (EmptyReturnException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpPatch("{folderId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> UpdateFolder([FromBody] UpdateFolderRequest request, Guid folderId)
    {
        try
        {
            if (folderId != request.Id) return BadRequest("folder to update does not match endpoint");
            await folderService.UpdateAsync(request);
            return Ok("Folder has been updated");
        }
        catch (EmptyReturnException e)
        {
            return NotFound(e.Message);
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
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> DeleteFolder(Guid folderId)
    {
        try
        {
            await folderService.DeleteAsync(folderId);
            return NoContent();
        }
        catch (EmptyReturnException e)
        {
            return NotFound(e.Message);
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