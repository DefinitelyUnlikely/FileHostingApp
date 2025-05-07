using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

// We might separarte FileData into its own model.
public class FileMeta
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public long FileSize { get; set; }
    public required string Extension { get; set; }

    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Guid? FolderId { get; set; }
    [ForeignKey("FolderId")]
    public Folder? Folder { get; set; }

    public required string UserId { get; set; }
    [ForeignKey("UserId")]
    public IdentityUser? User { get; set; }

    public FileData? FileData { get; set; }

}