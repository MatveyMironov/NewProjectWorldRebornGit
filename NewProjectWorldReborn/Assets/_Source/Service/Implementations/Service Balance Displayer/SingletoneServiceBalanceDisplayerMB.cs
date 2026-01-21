using CustomUISystem;
using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class SingletoneServiceBalanceDisplayerMB : AServiceBalanceDisplayerMB
    {
        [SerializeField] private ServiceDefinitionDisplayerMB serviceDefinitionDisplayer;
        [SerializeField] private ANumberDisplayerMB totalServiceSupplyDisplayer;

        private IServicesManager _servicesManager;

        private SuppliesManager _displayedServiceBalance;

        private void Awake()
        {
            _servicesManager = ServicesManagerSingleton.Instance;
        }

        public override void DisplayServiceBalance(IServiceDefinition service)
        {
            Clear();

            serviceDefinitionDisplayer.DisplayServiceDefinition(service);

            if (!_servicesManager.TryGetServiceBalance(service, out var balance))
            {
                if (!_servicesManager.TryAddServiceBalance(service, out balance))
                {
                    return;
                }
            }

            DisplayTotalSupply(balance.TotalSupply);
            balance.OnTotalSupplyChanged += DisplayServiceBalanceTotalSupply;

            _displayedServiceBalance = balance;
        }

        public override void Clear()
        {
            if (_displayedServiceBalance == null) return;

            serviceDefinitionDisplayer.Clear();

            _displayedServiceBalance.OnTotalSupplyChanged -= DisplayServiceBalanceTotalSupply;
            totalServiceSupplyDisplayer.DisplayNumber(0);

            _displayedServiceBalance = null;
        }

        private void DisplayServiceBalanceTotalSupply()
        {
            DisplayTotalSupply(_displayedServiceBalance.TotalSupply);
        }

        private void DisplayTotalSupply(int totalSupply)
        {
            totalServiceSupplyDisplayer.DisplayNumber(totalSupply);
        }
    }
}