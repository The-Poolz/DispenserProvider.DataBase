using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class BuilderDTO
{
    public int Id { get; set; }

    [Column(TypeName = "decimal(36,18)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "datetime2(0)")]
    public DateTime? StartTime { get; set; }

    [Column(TypeName = "datetime2(0)")]
    public DateTime? FinishTime { get; set; }

    public int TransactionDetailId { get; set; }
    public virtual TransactionDetailDTO TransactionDetail { get; set; } = null!;
}