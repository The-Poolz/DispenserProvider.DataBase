namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public int Id { get; set; }
    public decimal WithdrawalAmount { get; set; }
    public decimal RefundAmount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }

    public string ProviderAddress { get; set; }

    public int TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; }
}