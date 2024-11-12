namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public int Id { get; set; }
    public string Parameters { get; set; }
    public string ProviderAddress { get; set; }

    public int TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; }
}