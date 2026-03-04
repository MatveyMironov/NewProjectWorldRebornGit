using UnityEngine;

namespace EfficiencySystem
{
    public abstract class AEfficiencyConfigurationSO : ScriptableObject, IEfficiencyConfiguration
    {
        public abstract IEfficiency GetEfficiency();
    }
}