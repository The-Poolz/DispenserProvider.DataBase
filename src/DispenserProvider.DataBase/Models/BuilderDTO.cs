namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public long Id { get; set; }

    public string ProviderAddress { get; set; } = null!;

    public string WeiAmount { get; set; } = null!;

    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? FinishTime { get; set; }

    public long TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; } = null!;
}