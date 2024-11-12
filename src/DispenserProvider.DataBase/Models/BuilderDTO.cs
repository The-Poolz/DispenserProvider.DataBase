namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? FinishTime { get; set; }

    public int TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; }
}