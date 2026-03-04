using System;

namespace EfficiencySystem.Implementations
{
    public class ConstantEfficiency : IEfficiency
    {
        public ConstantEfficiency(float efficiency)
        {
            Efficiency = efficiency < 0 ? throw new ArgumentOutOfRangeException("Efficiency can't be negative") : efficiency;
        }

        public float Efficiency { get; }

        public event Action OnEfficiencyChanged;
    }
}