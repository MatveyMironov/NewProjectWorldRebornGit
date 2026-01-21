using System;

namespace ServiceSystem
{
    public class ServiceProvider : IServiceSupply
    {
        public IServiceDefinition ProvidedService { get; }

        public ServiceProvider(IServiceDefinition providedService, int suppliedAmount)
        {
            ProvidedService = providedService ?? throw new ArgumentNullException(nameof(providedService));
            SuppliedAmount = suppliedAmount;
        }

        public int SuppliedAmount { get; }
        public event Action OnSuppliedAmountChanged;
    }
}