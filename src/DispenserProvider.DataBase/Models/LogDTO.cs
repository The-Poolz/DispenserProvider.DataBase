using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class LogDTO
{
    [Column(TypeName = "nvarchar(66)")]
    public string Signature { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime CreationTime { get; set; }

    public virtual List<DispenserDTO> Dispenser { get; set; } = null!;
}