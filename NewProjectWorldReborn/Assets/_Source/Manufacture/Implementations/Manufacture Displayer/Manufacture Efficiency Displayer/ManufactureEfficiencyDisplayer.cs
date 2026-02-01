using CustomUISystem;
using System;

namespace ManufactureSystem.Implementations
{
    public class ManufactureEfficiencyDisplayer : IManufactureEfficiencyDisplayer
    {
        private readonly INumberDisplayer _efficiencyValueDisplayer;

        public ManufactureEfficiencyDisplayer(INumberDisplayer efficiencyValueDisplayer)
        {
            _efficiencyValueDisplayer = efficiencyValueDisplayer ?? throw new ArgumentNullException(nameof(efficiencyValueDisplayer));
        }

        private IManufacture _displayedManufacture;

        public void DisplayManufacture(IManufacture manufacture)
        {
            Clear();

            manufacture.OnEfficicencyChanged += DisplayManufactureEfficiency;
            DisplayEfficicency(manufacture.Efficiency);

            _displayedManufacture = manufacture;
        }

        public void Clear()
        {
            if (_displayedManufacture == null) return;

            _displayedManufacture.OnEfficicencyChanged -= DisplayManufactureEfficiency;
            DisplayEfficicency(0.0f);

            _displayedManufacture = null;
        }

        private void DisplayManufactureEfficiency()
        {
            DisplayEfficicency(_displayedManufacture.Efficiency);
        }

        private void DisplayEfficicency(float efficiency)
        {
            _efficiencyValueDisplayer.DisplayNumber(efficiency);
        }
    }
}