using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class FileData
{
    public required Guid Id { get; set; }

    public required Guid FileMetaId { get; set; }

    [ForeignKey("FileMetaId")]
    public FileMeta? FileMeta { get; set; }

    public required byte[] Bytes { get; set; }
}