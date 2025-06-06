using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;




[ApiController]
[Route("[controller]")]
public class FolderController(IFolderService folderService) : ControllerBase
{
    [Authorize]
    [HttpPost()]
    public async Task<IActionResult> CreateFolder([FromBody] CreateFolderRequest request)
    {
        try
        {
            await folderService.CreateAsync(request);
            return Created();
        }
        catch (UnauthorizedAccessException)
        {
            return NotFound();
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
    [Authorize]
    public async Task<IActionResult> GetFolder(Guid folderId)
    {
        try
        {
            var response = await folderService.GetAsync(folderId, Request.Headers.TryGetValue("X-Include-Files", out _));
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
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

    [HttpGet("folders/user")]
    [Authorize]
    public async Task<IActionResult> GetFolders()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return BadRequest("The token is either not valid or is not associated with any users. Try refreshing your token.");
            }

            var response = await folderService.GetAllUserFoldersAsync(userId, Request.Headers.TryGetValue("X-Include-Files", out _));
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
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

    [HttpGet("folders/user/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetFoldersByUserId(string userId)
    {
        try
        {
            var response = await folderService.GetAllUserFoldersAsync(userId, Request.Headers.TryGetValue("X-Include-Files", out _));
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
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

    [HttpGet("root")]
    [Authorize]
    public async Task<IActionResult> GetRootFolder()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return BadRequest("The token is either not valid or is not associated with any users. Try refreshing your token.");
            }

            var response = await folderService.GetRootAsync(userId, Request.Headers.TryGetValue("X-Include-Files", out _));
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
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
    [Authorize]
    public async Task<IActionResult> UpdateFolder([FromBody] UpdateFolderRequest request, Guid folderId)
    {
        try
        {
            if (folderId != request.Id) return BadRequest("folder to update does not match endpoint");
            await folderService.UpdateAsync(request);
            return Ok("Folder has been updated");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.Write(e);
            return Forbid();
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
    [Authorize]
    public async Task<IActionResult> DeleteFolder(Guid folderId)
    {
        try
        {
            await folderService.DeleteAsync(folderId);
            return NoContent();
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
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