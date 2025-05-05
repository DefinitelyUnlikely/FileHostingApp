using Backend.DTO;
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
        return Ok();
    }

    [HttpGet("{folderId}")]
    public async Task<IActionResult> GetFolder(string folderId)
    {
        return Ok();
    }

    [HttpPatch("{folderId}")]
    public async Task<IActionResult> UpdateFolder([FromBody] UpdateFolderRequest request, string folderId)
    {
        return Ok();
    }

    [HttpDelete("{folderId}")]
    public async Task<IActionResult> DeleteFolder(string folderId)
    {
        return Ok();
    }
}