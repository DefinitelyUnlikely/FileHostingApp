using Backend.Exceptions;
using Backend.Interfaces;
using Backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController(IFileService fileService) : ControllerBase
{

    [HttpPost()]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> UploadFile([FromBody] CreateFileRequest request)
    {
        try
        {
            await fileService.CreateAsync(request);
            return Created();
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (NoChangesSavedException)
        {
            return StatusCode(500); // I need to figure out what error is appropiate here.
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpGet("{fileId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetFile(Guid fileId)
    {
        try
        {
            var response = await fileService.GetByIdAsync(fileId);
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return NotFound();
        }
        catch (EmptyReturnException)
        {
            return NotFound("No file with that Id was found.");
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpPatch("{fileId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> UpdateFile([FromBody] UpdateFileRequest request, Guid fileId)
    {
        try
        {
            if (fileId != request.Id) return BadRequest("Id of request does not match id of route, please double check.");

            await fileService.UpdateAsync(request);
            return Ok("File has been updated");
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (ArgumentException)
        {
            return BadRequest("Request contains bad information.");
        }
        catch (EmptyReturnException)
        {
            return NotFound("No file with that Id was found.");
        }
        catch (NoChangesSavedException)
        {
            return StatusCode(500); // I need to figure out what error is appropiate here.
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    [HttpDelete("{fileId}")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DeleteFile(Guid fileId)
    {
        try
        {
            await fileService.DeleteAsync(fileId);
            return NoContent();
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (EmptyReturnException)
        {
            return NotFound("File could not be found");
        }
        catch (Exception)
        {
            return BadRequest("An unexpected error happened, double check your request data");
        }
    }

    // We might want to add an endpoint that downloads the file. Get currently sends it as json
    // with a bytearray. We keep that as a techincal implimentation, but add download as a thing that 
    // your everyday user might use.
    [HttpGet("download/{id}")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DownloadFile(Guid id)
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}