using ConstructionGridSystem;
using System;

namespace DemolishingSystem
{
    public interface IDemolitionController
    {
        public event Action OnBuildingSelected;
        public event Action OnBuildingDeselected;
        public event Action<BuildingStructure> OnBuildingDemolished;

        event Action OnStateEntered;
        event Action OnStateExited;

        public void StartDemolishing();
        void ConfirmDemolition();
        void DenyDemolition();
    }
}