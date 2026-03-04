using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public interface IManufacture
    {
        public Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested;
        public Dictionary<IResourceDefinition, int> ProducedResources { get; }
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested;

        public float Time { get; }

        public bool IsStarted { get; }
        public bool IsPossible { get; }

        public float Progress { get; }
        public event Action OnProgressChanged;

        public bool IsPaused { get; }
        public event Action OnPaused;
        public event Action OnResumed;

        public void StartManufacture();
        public void AbortManufacture();
        public void ProgressManufacture();
        bool TryPause();
        bool TryResume();
    }
}