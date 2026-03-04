using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public interface IManufacture
    {
        public int ManufactureTime { get; }

        public Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested;
        public Dictionary<IResourceDefinition, int> ProducedResources { get; }
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested;

        public float Progress { get; }
        public event Action OnProgressChanged;

        public bool IsPaused { get; set; }
        public event Action OnPaused;
        public event Action OnUnpaused;

        public bool IsStarted { get; }
        public bool IsPossible { get; }

        public void StartManufacture();
        public void AbortManufacture();
        public void ProgressManufacture();
    }
}