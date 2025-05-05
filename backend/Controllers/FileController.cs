using Backend.Interfaces;
using Backend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("file")]
public class FileController(IFileService fileService) : ControllerBase
{

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromBody] CreateFileRequest request)
    {
        return Ok();
    }

    [HttpGet("{fileId}")]
    public async Task<IActionResult> GetFile(string fileId)
    {
        return Ok();
    }

    [HttpPatch("update/{fileId}")]
    public async Task<IActionResult> UpdateFile([FromBody] UpdateFileRequest request, string fileId)
    {
        return Ok();
    }

    [HttpDelete("{fileId}")]
    public async Task<IActionResult> DeleteFile(string fileId)
    {
        return Ok();
    }
}