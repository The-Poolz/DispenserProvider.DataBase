namespace DispenserProvider.DataBase.Models;

public class DispenserProviderDTO
{
    public string Id => $"HASH OF {UserAddress}+{WithdrawalDetailId}";

    public string UserAddress { get; set; } = null!;

    public string? Signature { get; set; }
    public virtual SignatureDTO UserSignature { get; set; }

    public string WithdrawalDetailId { get; set; }
    public virtual TransactionDetailDTO WithdrawalDetail { get; set; }

    public string? RefundDetailId { get; set; }
    public virtual TransactionDetailDTO? RefundDetail { get; set; }
}