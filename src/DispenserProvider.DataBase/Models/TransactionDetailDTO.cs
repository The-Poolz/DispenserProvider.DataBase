namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    public string Id => $"HASH OF {DispenserProvider.UserAddress}+{ChainId}+{PoolId}";
    public long ChainId { get; set; }
    public long PoolId { get; set; }

    public virtual List<BuilderDTO> Builders { get; set; } = new();

    public string DispenserProviderId { get; set; }
    public virtual DispenserProviderDTO DispenserProvider { get; set; }
}