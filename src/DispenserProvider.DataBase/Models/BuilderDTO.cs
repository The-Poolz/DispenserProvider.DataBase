namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    // PRIMARY KEY: Id
    // FOREIGN KEY: UserAddress + ChainId + PoolId
    // NOTE: Scheme like this we have relationship in 'DownloaderSettings' and 'DownloaderMapping', in 'DownloaderMapping' we use default auto-incremented integer ID.
    // With this scheme we avoid duplicates by (UserAddress + ChainId + PoolId), but ID is simple auto-incremented integer ID.

    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? FinishTime { get; set; }

    // Inherit this data from TransactionDetail to avoid duplicates like in 'DownloaderMapping' table.
    public string UserAddress { get; set; }
    public long ChainId { get; set; }
    public long PoolId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; }
}