using System;

namespace ServiceSystem
{
    public interface IServiceSupply
    {
        int SuppliedAmount { get; }
        event Action OnSuppliedAmountChanged;
    }
}