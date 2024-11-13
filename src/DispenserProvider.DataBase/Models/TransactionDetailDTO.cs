namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    public int Id { get; set; }
    public long ChainId { get; set; }
    public long PoolId { get; set; }

    public virtual List<BuilderDTO> Builders { get; set; } = [];
    public virtual DispenserProviderDTO DispenserProvider { get; set; } = null!;
}