namespace DispenserProvider.DataBase.Models;

public class UserDTO
{
    public string UserAddress { get; set; }

    public string? Signature { get; set; }
    public virtual SignatureDTO? UserSignature { get; set; }

    public virtual TransactionDetailDTO WithdrawalTransactions { get; set; }
    public virtual TransactionDetailDTO? RefundTransactions { get; set; }
}