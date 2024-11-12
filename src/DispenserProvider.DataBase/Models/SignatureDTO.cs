using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class SignatureDTO
{
    [Column(TypeName = "nvarchar(450)")]
    public string Signature { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime ValidFrom { get; set; }

    [Column(TypeName = "datetime2(0)")]
    public DateTime ValidUntil { get; set; }

    public bool IsRefund { get; set; }

    public virtual DispenserProviderDTO DispenserProvider { get; set; } = null!;
}