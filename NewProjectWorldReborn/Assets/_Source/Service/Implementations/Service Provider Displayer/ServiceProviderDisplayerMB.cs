using CustomUISystem;
using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class ServiceProviderDisplayerMB : AServiceProviderDisplayerMB
    {
        [SerializeField] private ServiceDefinitionDisplayerMB providedServiceDisplayer;
        [SerializeField] private ANumberDisplayerMB providedAmountDisplayer;

        private ServiceProvider _displayedProvider;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayServiceProvider(ServiceProvider provider)
        {
            Clear();

            providedServiceDisplayer.DisplayServiceDefinition(provider.ProvidedService);

            DisplayProvidedAmount(provider.SuppliedAmount);
            provider.OnSuppliedAmountChanged += DisplayProviderProvidedAmount;

            _displayedProvider = provider;
        }

        public override void Clear()
        {
            if (_displayedProvider == null) return;

            providedServiceDisplayer.Clear();

            _displayedProvider.OnSuppliedAmountChanged -= DisplayProviderProvidedAmount;
            DisplayProvidedAmount(0);

            _displayedProvider = null;
        }

        private void DisplayProviderProvidedAmount()
        {
            DisplayProvidedAmount(_displayedProvider.SuppliedAmount);
        }

        private void DisplayProvidedAmount(int providedAmount)
        {
            providedAmountDisplayer.DisplayNumber(providedAmount);
        }
    }
}