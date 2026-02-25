using CustomInfoSystem;
using ServiceSystem;
using System;

namespace ProgressionSystem.Implementations
{
    public class ServiceTask : ITask
    {
        private readonly SuppliesManager _serviceBalance;

        public ServiceTask(IServiceDefinition requiredService, int requiredAmount, SuppliesManager serviceBalance, ServiceTaskDisplayerMB displayerPrefab)
        {
            RequiredService = requiredService ?? throw new ArgumentNullException(nameof(requiredService));
            RequiredAmount = requiredAmount;

            _serviceBalance = serviceBalance ?? throw new ArgumentNullException(nameof(serviceBalance));
            _serviceBalance.OnTotalSupplyChanged += CheckSupply;

            Info = new ServiceTaskInfo(this, displayerPrefab);

            void CheckSupply()
            {
                if (_serviceBalance.TotalSupply >= RequiredAmount)
                {
                    IsCompleted = true;
                    OnCompleted?.Invoke();
                    _serviceBalance.OnTotalSupplyChanged -= CheckSupply;
                }
            }
        }

        public IServiceDefinition RequiredService;
        public int RequiredAmount;

        public int Supply => _serviceBalance.TotalSupply;
        public event Action OnSupplyChanged
        {
            add => _serviceBalance.OnTotalSupplyChanged += value;
            remove => _serviceBalance.OnTotalSupplyChanged -= value;
        }

        public bool IsCompleted { get; private set; }
        public event Action OnCompleted;

        public ICustomInfo Info { get; }
    }
}