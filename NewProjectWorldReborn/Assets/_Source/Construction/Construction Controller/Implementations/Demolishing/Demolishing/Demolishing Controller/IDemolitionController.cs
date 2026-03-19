using ConstructionGridSystem;
using System;

namespace DemolishingSystem
{
    public interface IDemolitionController
    {
        event Action OnBuildingSelected;
        event Action OnBuildingDeselected;
        event Action<BuildingStructure> OnBuildingDemolished;

        event Action OnStateEntered;
        event Action OnStateExited;

        void StartDemolishing();
    }
}