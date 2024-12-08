﻿using DispenserProvider.DataBase.Models.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispenserProvider.DataBase.Models;

public class LogDTO
{
    [Column(TypeName = "nvarchar(132)")]
    public string Signature { get; set; } = null!;

    [Column(TypeName = "datetime2(0)")]
    public DateTime CreationTime { get; set; }

    [Column(TypeName = "nvarchar(32)")]
    public OperationType Operation { get; set; }

    public virtual List<DispenserDTO> CreationDispensers { get; set; } = [];
    public virtual List<DispenserDTO> DeletionDispensers { get; set; } = [];
}