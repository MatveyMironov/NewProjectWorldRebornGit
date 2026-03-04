using UnityEngine;

namespace EfficiencySystem.Implementations
{
    [CreateAssetMenu(fileName = "New Constant Efficiency", menuName = "Efficiency Configuration/Constant Efficiency")]
    public class ConstantEfficiencyConfigurationSO : AEfficiencyConfigurationSO
    {
        [Tooltip("Efficiency should be greater then 0")]
        [SerializeField] private float efficiency;

        public override IEfficiency GetEfficiency()
        {
            return new ConstantEfficiency(efficiency);
        }
    }
}