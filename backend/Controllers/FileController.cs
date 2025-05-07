using Backend.Exceptions;
using Backend.Interfaces;
using Backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend.Controllers;

[ApiController]
[Route("file")]
public class FileController(IFileService fileService) : ControllerBase
{

    [HttpPost()]
    public async Task<IActionResult> UploadFile([FromBody] CreateFileRequest request)
    {
        try
        {
            await fileService.CreateAsync(request);
            return Created();
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
    public async Task<IActionResult> GetFile(Guid fileId)
    {
        try
        {
            var response = await fileService.GetByIdAsync(fileId);
            return Ok(response);
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
    public async Task<IActionResult> UpdateFile([FromBody] UpdateFileRequest request, Guid fileId)
    {
        try
        {
            if (fileId != request.Id) return BadRequest("Id of request does not match id of route, please double check.");

            await fileService.UpdateAsync(request);
            return Ok("File has been updated");
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
    public async Task<IActionResult> DeleteFile(Guid fileId)
    {
        try
        {
            await fileService.DeleteAsync(fileId);
            return NoContent();
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
}