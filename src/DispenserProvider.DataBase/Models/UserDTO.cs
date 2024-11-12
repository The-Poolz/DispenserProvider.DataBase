namespace DispenserProvider.DataBase.Models;

public class UserDTO
{
    public string UserAddress { get; set; } = null!;

    public virtual List<TransactionDetailDTO> WithdrawalTransactions { get; set; }
    //public virtual List<TransactionDetailDTO> WithdrawalTransactions { get; set; }
    //public virtual List<TransactionDetailDTO>? RefundTransactions { get; set; }
}