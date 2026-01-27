using BuildingConstructionUISystem;
using ConstructionGridSystem;
using System;

namespace BuildingSystem
{
    public class BuildingConstructionsManager : IBuildingConstructionsManager
    {
        private readonly IStructureBuildingsManager _correspondancesManager;
        private readonly IBuildingConstructionButtonsManager _constructionButtonsManager;

        public BuildingConstructionsManager(IStructureBuildingsManager correspondancesManager, IBuildingConstructionButtonsManager constructionButtonsManager)
        {
            _correspondancesManager = correspondancesManager ?? throw new ArgumentNullException(nameof(correspondancesManager));
            _constructionButtonsManager = constructionButtonsManager ?? throw new ArgumentNullException(nameof(constructionButtonsManager));
        }

        public bool TryAddBuildingConstruction(IBuildingConfiguration configuration)
        {
            return _constructionButtonsManager.TryAddConstructionButton(configuration, CreateBuilding);

            void CreateBuilding(ConstructedBuilding structure)
            {
                Building building = configuration.CreateBuilding(structure);
                _correspondancesManager.TryAddStructureBuilding(structure, building);
            }
        }

        public bool TryRemoveBuildingConstruction(IBuildingConfiguration configuration)
        {
            return _constructionButtonsManager.TryRemoveConstructionButton(configuration);
        }
    }
}