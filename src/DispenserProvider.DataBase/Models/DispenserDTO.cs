using Net.Web3.EthereumWallet;
using Net.Cryptography.SHA256;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class DispenserDTO
{
    [Column(TypeName = "nvarchar(64)")]
    public string Id { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime? RefundFinishTime { get; set; }

    public virtual List<SignatureDTO> UserSignatures { get; set; } = [];

    [NotMapped]
    public SignatureDTO? LastUserSignature => UserSignatures.Count <= 0 ? null : UserSignatures.MaxBy(x => x.ValidUntil);

    public virtual TakenTrackDTO? TakenTrack { get; set; }

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

    public DispenserDTO(TransactionDetailDTO withdraw, TransactionDetailDTO? refund)
    {
        Id = GenerateId(withdraw, refund);
    }

    public DispenserDTO(EthereumAddress userAddress, long withdrawChainId, long withdrawPoolId, long? refundChainId = null, long? refundPoolId = null)
    {
        Id = GenerateId(userAddress, withdrawChainId, withdrawPoolId, refundChainId, refundPoolId);
    }

    public static string GenerateId(TransactionDetailDTO withdraw, TransactionDetailDTO? refund = null)
    {
        return GenerateId(withdraw.UserAddress, withdraw.ChainId, withdraw.PoolId, refund?.ChainId, refund?.PoolId);
    }

    public static string GenerateId(EthereumAddress userAddress, long withdrawChainId, long withdrawPoolId, long? refundChainId = null, long? refundPoolId = null)
    {
        return GenerateSourceForId(userAddress, withdrawChainId, withdrawPoolId, refundChainId, refundPoolId).ToSha256();
    }

    internal static string GenerateSourceForId(EthereumAddress userAddress, long withdrawChainId, long withdrawPoolId, long? refundChainId = null, long? refundPoolId = null)
    {
        return $"{userAddress}-{withdrawChainId}-{withdrawPoolId}" + (refundChainId.HasValue && refundPoolId.HasValue ? $"-{refundChainId}-{refundPoolId}" : string.Empty);
    }
}