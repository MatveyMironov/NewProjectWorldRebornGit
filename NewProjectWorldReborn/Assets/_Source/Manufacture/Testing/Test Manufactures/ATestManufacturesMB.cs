using EfficiencySystem;
using UnityEngine;

namespace ManufactureSystem.Testing
{
    public abstract class ATestManufacturesMB : MonoBehaviour
    {
        [SerializeField] private SManufactureConfiguration[] _manufactureConfigurations = new SManufactureConfiguration[0];

        protected abstract IManufacturesManager ManufacturesManager { get; }

        protected virtual void Start()
        {
            foreach (var configuration in _manufactureConfigurations)
            {
                IEfficiency efficiency = new ConstantEfficiency();
                IManufacture manufacture = configuration.CreateManufacture(efficiency);
                ManufacturesManager.TryAddManufacture(manufacture);
            }
        }
    }
}