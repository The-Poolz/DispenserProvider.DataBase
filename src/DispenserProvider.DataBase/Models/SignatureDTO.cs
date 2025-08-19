namespace DispenserProvider.DataBase.Models;

public class SignatureDTO
{
    public string Signature { get; set; } = null!;

    public DateTimeOffset ValidFrom { get; set; }

    public DateTimeOffset ValidUntil { get; set; }

    public bool IsRefund { get; set; }

    public string DispenserId { get; set; } = null!;
    public virtual DispenserDTO Dispenser { get; set; } = null!;
}