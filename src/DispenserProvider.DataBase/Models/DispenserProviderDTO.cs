namespace DispenserProvider.DataBase.Models;

public class DispenserProviderDTO
{
    public int Id { get; set; }

    /// <summary>
    /// This field will be set by the administrator during initialization.
    /// </summary>
    public string UserAddress { get; set; } = null!;


    #region Signature part

    public string Signature { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }

    // or

    //public string? UserSignature { get; set; }
    //public virtual SignatureDTO Signature { get; set; }

    #endregion

    public bool IsRefund { get; set; }

    public int WithdrawalDetailId { get; set; }
    public virtual TransactionDetailDTO WithdrawalDetail { get; set; }

    public int? RefundDetailId { get; set; }
    public virtual TransactionDetailDTO? RefundDetail { get; set; }
}