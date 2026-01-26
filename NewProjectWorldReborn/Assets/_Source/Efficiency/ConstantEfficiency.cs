using System;

namespace EfficiencySystem
{
    public class ConstantEfficiency : IEfficiency
    {
        public ConstantEfficiency()
        {
            Efficiency = 1.0f;
        }

        public float Efficiency { get; }

        public event Action OnEfficiencyChanged;
    }
}
