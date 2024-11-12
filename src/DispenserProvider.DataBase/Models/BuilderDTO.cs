namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public string Id => $"HASH OF {TransactionDetailId}+{Amount}+{StartTime}+{FinishTime}";
    public decimal Amount { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? FinishTime { get; set; }

    public long TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; }
}