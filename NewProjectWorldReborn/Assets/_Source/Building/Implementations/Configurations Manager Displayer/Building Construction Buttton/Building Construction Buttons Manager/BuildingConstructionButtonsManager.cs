using BuildingSystem;
using ConstructionGridSystem;
using PlacingSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingConstructionUISystem
{
    public class BuildingConstructionButtonsManager : IBuildingConstructionButtonsManager
    {
        private readonly IBuildingConstructionButtonSpawner _constructionButtonSpawner;
        private readonly IPlacingInvokeCreator _placingInvokeCreator;

        private readonly IStructureBuildingsManager _structureBuildingsManager;

        public BuildingConstructionButtonsManager(IBuildingConstructionButtonSpawner constructionButtonSpawner,
                                                  IPlacingInvokeCreator placingInvokeCreator,
                                                  IStructureBuildingsManager structureBuildingsManager)
        {
            _constructionButtonSpawner = constructionButtonSpawner ?? throw new ArgumentNullException(nameof(constructionButtonSpawner));
            _placingInvokeCreator = placingInvokeCreator ?? throw new ArgumentNullException(nameof(placingInvokeCreator));
            _structureBuildingsManager = structureBuildingsManager ?? throw new ArgumentNullException(nameof(structureBuildingsManager));
        }

        private readonly Dictionary<IBuildingConfiguration, BuildingConstructionButtonMB> _buildingConstructionButtons = new();

        public bool TryAddConstructionButton(IBuildingConfiguration configuration)
        {
            if (_buildingConstructionButtons.TryAdd(configuration, null))
            {
                BuildingConstructionButtonMB button = _constructionButtonSpawner.SpawnButton();
                _buildingConstructionButtons[configuration] = button;
                button.DisplayBuildingConfiguration(configuration);

                BuildingConstructionConfiguration constructionConfiguration = new(configuration, _structureBuildingsManager);
                button.OnButtonClicked += _placingInvokeCreator.CreatePlacingInvoke(constructionConfiguration);

                //Debug.Log($"Building construction button added for configuration: {configuration}");

                return true;
            }

            return false;
        }

        public bool TryRemoveConstructionButton(IBuildingConfiguration configuration)
        {
            if (_buildingConstructionButtons.Remove(configuration, out var button))
            {
                UnityEngine.Object.Destroy(button.gameObject);
                //Debug.Log($"Building construction button removed of configuration: {configuration}");
                return true;
            }

            return false;
        }

        private class BuildingConstructionConfiguration : IConstructionConfiguration
        {
            private readonly IBuildingConfiguration _buildingConfiguration;

            private readonly IStructureBuildingsManager _structureBuildingsManager;

            public BuildingConstructionConfiguration(IBuildingConfiguration buildingConfiguration, IStructureBuildingsManager structureBuildingsManager)
            {
                _buildingConfiguration = buildingConfiguration ?? throw new ArgumentNullException(nameof(buildingConfiguration));
                _structureBuildingsManager = structureBuildingsManager ?? throw new ArgumentNullException(nameof(structureBuildingsManager));
            }

            public HashSet<Vector2Int> OccupiedCells => _buildingConfiguration.OccupiedCells;
            public ConstructionPreviewMB ConstructionPreviewPrefab => _buildingConfiguration.ConstructionPreviewPrefab;

            public BuildingStructure CreateBuildingStructure()
            {
                Building building = _buildingConfiguration.CreateBuilding();
                _structureBuildingsManager.TryAddStructureBuilding(building.Structure, building);
                return building.Structure;
            }
        }
    }
}