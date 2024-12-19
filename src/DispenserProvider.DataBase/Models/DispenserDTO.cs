using Net.Web3.EthereumWallet;
using Net.Cryptography.SHA256;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class DispenserDTO
{
    [Column(TypeName = "nvarchar(64)")]
    public string Id { get; set; } = null!;

    [Column(TypeName = "nvarchar(42)")]
    public string UserAddress { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime? RefundFinishTime { get; set; }

    [Column(TypeName = "nvarchar(132)")]
    public string? Signature { get; set; }
    public virtual SignatureDTO? UserSignature { get; set; } = null!;

    public long WithdrawalDetailId { get; set; }
    public virtual TransactionDetailDTO WithdrawalDetail { get; set; } = null!;

    public long? RefundDetailId { get; set; }
    public virtual TransactionDetailDTO? RefundDetail { get; set; }

    [Column(TypeName = "nvarchar(132)")]
    public string CreationLogSignature { get; set; } = null!;
    public virtual LogDTO CreationLog { get; set; } = null!;

    [Column(TypeName = "nvarchar(132)")]
    public string? DeletionLogSignature { get; set; }
    public virtual LogDTO? DeletionLog { get; set; }

    public DispenserDTO() { }

    public DispenserDTO(EthereumAddress userAddress, long chainId, long poolId)
    {
        Id = GenerateId(userAddress, chainId, poolId);
    }

    public static string GenerateId(EthereumAddress userAddress, long chainId, long poolId)
    {
        return $"{userAddress}-{chainId}-{poolId}".ToSha256();
    }
}