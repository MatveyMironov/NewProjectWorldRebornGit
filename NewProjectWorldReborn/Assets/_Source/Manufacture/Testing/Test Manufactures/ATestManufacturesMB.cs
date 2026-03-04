using EfficiencySystem;
using UnityEngine;

namespace ManufactureSystem.Testing
{
    public abstract class ATestManufacturesMB : MonoBehaviour
    {
        [SerializeField] private SManufactureConfiguration[] manufactureConfigurations = new SManufactureConfiguration[0];
        [SerializeField] private AEfficiencyConfigurationSO efficiencyConfiguration;

        protected abstract IManufacturesManager ManufacturesManager { get; }

        protected virtual void Start()
        {
            foreach (var configuration in manufactureConfigurations)
            {
                IEfficiency efficiency = efficiencyConfiguration.GetEfficiency();
                IManufacture manufacture = configuration.CreateManufacture(efficiency);
                ManufacturesManager.TryAddManufacture(manufacture);
            }
        }
    }
}