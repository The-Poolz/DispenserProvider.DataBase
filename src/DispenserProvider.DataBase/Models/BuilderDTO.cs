using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public long Id { get; set; }

    [Column(TypeName = "nvarchar(42)")]
    public string ProviderAddress { get; set; } = null!;

    [Column(TypeName = "nvarchar(78)")]
    public string WeiAmount { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime? StartTime { get; set; }

    [Column(TypeName = "datetime2(0)")]
    public DateTime? FinishTime { get; set; }

    public long TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; } = null!;
}