using ConstructionGridSystem;
using System;

namespace DemolishingSystem
{
    public interface IDemolishingInvoker
    {
        BuildingStructure SelectedStructure { get; }

        event Action OnStructureSelected;
        event Action OnStructureDeselected;
        event Action<BuildingStructure> OnBuildingDemolished;

        event Action OnStateEntered;
        event Action OnStateExited;

        void InvokeDemolishing();
    }
}