using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class LogDTO
{
    public string Signature { get; set; } = null!;

    public DateTimeOffset CreationTime { get; set; }

    public bool IsCreation { get; set; }

    [NotMapped]
    public bool IsDeletion => !IsCreation;

    public virtual List<DispenserDTO> CreationDispensers { get; set; } = [];
    public virtual List<DispenserDTO> DeletionDispensers { get; set; } = [];
}