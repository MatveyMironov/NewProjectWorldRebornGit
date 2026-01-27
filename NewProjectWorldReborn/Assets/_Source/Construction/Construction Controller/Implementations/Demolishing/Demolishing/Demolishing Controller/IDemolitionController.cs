using ConstructionGridSystem;
using System;

namespace DemolishingSystem
{
    public interface IDemolitionController
    {
        public event Action OnBuildingSelected;
        public event Action OnBuildingDeselected;
        public event Action<ConstructedBuilding> OnBuildingDemolished;

        public void StartDemolishing();
        void ConfirmDemolition();
        void DenyDemolition();
    }
}