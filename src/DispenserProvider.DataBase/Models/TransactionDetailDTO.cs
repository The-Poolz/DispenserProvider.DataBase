using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    public int Id { get; set; }
    public long ChainId { get; set; }
    public long PoolId { get; set; }

    public virtual List<BuilderDTO> Builders { get; set; } = [];

    [Column(TypeName = "nvarchar(450)")]
    public string DispenserProviderId { get; set; } = null!;
    public virtual DispenserProviderDTO DispenserProvider { get; set; } = null!;
}