namespace DispenserProvider.DataBase.Models;

public class SignatureDTO
{
    // PRIMARY KEY: Signature - cause here cannot be duplicates on generating signatures level
    public string Signature { get; set; }

    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public bool IsRefund { get; set; }
}