namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    public long Id { get; set; }

    // Create index for UserAddress + ChainId + PoolId
    public string UserAddress { get; set; }
    public long ChainId { get; set; }
    public long PoolId { get; set; }

    public virtual List<BuilderDTO> Builders { get; set; }

    public string? Signature { get; set; }
    public virtual SignatureDTO? UserSignature { get; set; }
}