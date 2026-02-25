using System;
using System.Collections.Generic;

namespace ServiceSystem
{
    public class SuppliesManager
    {
        private int _totalSupply;
        public event Action OnTotalSupplyChanged;
        public int TotalSupply
        {
            get
            {
                return _totalSupply;
            }
            set
            {
                _totalSupply = value;
                OnTotalSupplyChanged?.Invoke();
            }
        }

        private readonly Dictionary<IServiceSupply, Action> _supplies = new();
        public event Action<IServiceSupply> OnSupplyAdded;
        public event Action<IServiceSupply> OnSupplyRemoved;

        private readonly Dictionary<IServiceSupply, int> _accountedSupplies = new();
        public event Action<IServiceSupply> OnSupplyAccounted;
        public event Action<IServiceSupply> OnSupplyDiscounted;

        public bool TryAddSupply(IServiceSupply supply)
        {
            if (supply.SuppliedAmount <= 0) return false;

            if (_supplies.TryAdd(supply, AccountThisSupply))
            {
                supply.OnSuppliedAmountChanged += AccountThisSupply;
                AccountThisSupply();
                OnSupplyAdded?.Invoke(supply);
                return true;
            }

            return false;

            void AccountThisSupply()
            {
                AccountSupply(supply);
            }
        }

        public bool TryRemoveSupply(IServiceSupply supply)
        {
            if (_supplies.Remove(supply, out var accountThisSupply))
            {
                supply.OnSuppliedAmountChanged -= accountThisSupply;
                DiscountSupply(supply);
                OnSupplyRemoved?.Invoke(supply);
                return true;
            }

            return false; ;
        }

        private void AccountSupply(IServiceSupply supply)
        {
            DiscountSupply(supply);

            if (_accountedSupplies.TryAdd(supply, supply.SuppliedAmount))
            {
                TotalSupply += supply.SuppliedAmount;
                OnSupplyAccounted?.Invoke(supply);
            }
        }

        private void DiscountSupply(IServiceSupply supply)
        {
            if (_accountedSupplies.Remove(supply, out int accountedAmount))
            {
                TotalSupply -= accountedAmount;
                OnSupplyDiscounted?.Invoke(supply);
            }
        }
    }
}