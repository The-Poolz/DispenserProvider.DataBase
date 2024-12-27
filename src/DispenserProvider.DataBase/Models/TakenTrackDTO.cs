using DispenserProvider.DataBase.Models.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class TakenTrackDTO
{
    public long Id { get; set; }

    public TakenType Taken { get; set; }

    [Column(TypeName = "nvarchar(64)")]
    public string DispenserId { get; set; } = null!;

    public virtual DispenserDTO Dispenser { get; set; } = null!;
}