﻿namespace DispenserProvider.DataBase.Models;

public class TransactionDetailDTO
{
    public long Id { get; set; }
    public long ChainId { get; set; }
    public long PoolId { get; set; }

    public virtual List<BuilderDTO> Builders { get; set; } = [];
    public virtual DispenserDTO? WithdrawalDispenser { get; set; }
    public virtual DispenserDTO? RefundDispenser { get; set; }
}