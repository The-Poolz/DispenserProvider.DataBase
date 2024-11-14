using Net.Web3.EthereumWallet;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class DispenserDTO
{
    [Column(TypeName = "nvarchar(64)")]
    public string Id { get; set; } = null!;

    [Column(TypeName = "nvarchar(42)")]
    public string UserAddress { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime RefundFinishTime { get; set; }

    [Column(TypeName = "nvarchar(64)")]
    public string? Signature { get; set; }
    public virtual SignatureDTO UserSignature { get; set; } = null!;

    public long WithdrawalDetailId { get; set; }
    public virtual TransactionDetailDTO WithdrawalDetail { get; set; } = null!;

    public long? RefundDetailId { get; set; }
    public virtual TransactionDetailDTO? RefundDetail { get; set; }

    public DispenserDTO() { }

    public DispenserDTO(EthereumAddress userAddress, long chainId, long poolId)
    {
        Id = $"{userAddress}-{chainId}-{poolId}";
    }
}