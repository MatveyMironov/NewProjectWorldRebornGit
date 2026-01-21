using ConsumptionSystem;
using UnityEngine;

namespace NeedSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Resource Need", menuName = "Need Configuration/Consumption Need")]
    public class ConsumptionNeedConfigurationSO : ANeedConfigurationSO
    {
        [SerializeField] private SConsumptionConfiguration consumptionConfiguration;

        public override INeed CreateNeed()
        {
            Consumption consumption = consumptionConfiguration.CreateConsumption();
            ConsumptionNeed need = new(consumption);
            ResourceNeedsManagerSingleton.Instance.TryAddResourceNeedConsumption(need, consumption);
            return need;
        }
    }
}