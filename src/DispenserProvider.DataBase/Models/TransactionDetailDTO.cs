namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    // PRIMARY KEY: UserAddress + ChainId + PoolId
    // FOREIGN KEY: UserAddress

    public long ChainId { get; set; }
    public long PoolId { get; set; }
    public virtual List<BuilderDTO> Builders { get; set; }

    public string UserAddress { get; set; }
    public virtual UserDTO User { get; set; }

    public string? Signature { get; set; }
    public virtual SignatureDTO? UserSignature { get; set; }
}