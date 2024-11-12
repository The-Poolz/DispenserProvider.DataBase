namespace DispenserProvider.DataBase.Models;

public class SignatureDTO
{
    public string Signature { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public bool IsRefund { get; set; }
}