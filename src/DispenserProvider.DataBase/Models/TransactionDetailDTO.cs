using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    [Column(TypeName = "nvarchar(42)")]
    public string UserAddress { get; set; }
    public long ChainId { get; set; }
    public long PoolId { get; set; }

    public virtual List<BuilderDTO> Builders { get; set; } = [];
    public virtual DispenserDTO? WithdrawalDispenser { get; set; }
    public virtual DispenserDTO? RefundDispenser { get; set; }
}