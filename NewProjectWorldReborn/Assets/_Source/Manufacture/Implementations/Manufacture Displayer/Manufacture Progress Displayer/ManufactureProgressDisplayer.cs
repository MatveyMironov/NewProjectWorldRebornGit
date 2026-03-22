using CustomUISystem;
using System;

namespace ManufactureSystem.Implementations
{
    public class ManufactureProgressDisplayer : IManufactureProgressDisplayer
    {
        private readonly INumberDisplayer _progressValueDisplayer;

        public ManufactureProgressDisplayer(INumberDisplayer progressValueDisplayer)
        {
            _progressValueDisplayer = progressValueDisplayer ?? throw new ArgumentNullException(nameof(progressValueDisplayer));
        }

        private IManufacture _displayedManufacture;

        public void DisplayManufacture(IManufacture manufacture)
        {
            Clear();

            manufacture.OnProgressChanged += DisplayManufactureProgress;
            DisplayProgress(manufacture.Progress);

            _displayedManufacture = manufacture;
        }

        public void Clear()
        {
            if (_displayedManufacture == null) return;

            _displayedManufacture.OnProgressChanged -= DisplayManufactureProgress;
            DisplayProgress(0.0f);

            _displayedManufacture = null;
        }

        private void DisplayManufactureProgress()
        {
            DisplayProgress(_displayedManufacture.Progress);
        }

        private void DisplayProgress(float progress)
        {
            _progressValueDisplayer.DisplayNumber(progress);
        }
    }
}