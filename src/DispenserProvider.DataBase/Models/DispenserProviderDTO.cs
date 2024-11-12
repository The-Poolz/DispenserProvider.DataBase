using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class DispenserProviderDTO
{
    // $"HASH OF {UserAddress}+{WithdrawalDetail.ChainId}+{WithdrawalDetail.PoolId}";
    [Column(TypeName = "nvarchar(450)")]
    public string Id { get; set; } = null!;

    [Column(TypeName = "nvarchar(42)")]
    public string UserAddress { get; set; } = null!;

    [Column(TypeName = "nvarchar(450)")]
    public string? Signature { get; set; }
    public virtual SignatureDTO UserSignature { get; set; } = null!;

    public int WithdrawalDetailId { get; set; }
    public virtual TransactionDetailDTO WithdrawalDetail { get; set; } = null!;

    public int? RefundDetailId { get; set; }
    public virtual TransactionDetailDTO? RefundDetail { get; set; }
}