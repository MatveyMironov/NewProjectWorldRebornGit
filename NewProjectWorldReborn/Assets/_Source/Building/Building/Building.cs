using BuildingInfoSystem;
using ConstructionGridSystem;
using System;

namespace BuildingSystem
{
    public class Building
    {
        public Building(IBuildingConfiguration configuration, BuildingStructure structure, IBuildingInfo info)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Structure = structure ?? throw new ArgumentNullException(nameof(structure));
            Info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public IBuildingConfiguration Configuration { get; }
        public BuildingStructure Structure { get; }
        public IBuildingInfo Info { get; }

        public event Action OnInteractionShown { add => Structure.View.OnInteractionShown += value; remove => Structure.View.OnInteractionShown -= value; }
        public event Action OnInteractionHidden { add => Structure.View.OnInteractionHidden += value; remove => Structure.View.OnInteractionHidden -= value; }
        public event Action OnInteracted { add => Structure.View.OnInteracted += value; remove => Structure.View.OnInteracted -= value; }

        public event Action OnSelectedForDemolition { add => Structure.View.OnSelectedForDemolition += value; remove => Structure.View.OnSelectedForDemolition -= value; }
        public event Action OnDeselectedForDemolition { add => Structure.View.OnDeselectedForDemolition += value; remove => Structure.View.OnDeselectedForDemolition -= value; }

        public void Select()
        {
            Structure.View.Select();
        }

        public void Deselect()
        {
            Structure.View.Deselect();
        }
    }
}