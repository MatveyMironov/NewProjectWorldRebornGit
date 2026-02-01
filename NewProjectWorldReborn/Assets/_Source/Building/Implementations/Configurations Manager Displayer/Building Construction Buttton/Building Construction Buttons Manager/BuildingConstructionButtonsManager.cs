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

        public BuildingConstructionButtonsManager(IBuildingConstructionButtonSpawner constructionButtonSpawner, IPlacingInvokeCreator placingInvokeCreator)
        {
            _constructionButtonSpawner = constructionButtonSpawner ?? throw new ArgumentNullException(nameof(constructionButtonSpawner));
            _placingInvokeCreator = placingInvokeCreator ?? throw new ArgumentNullException(nameof(placingInvokeCreator));
        }

        private readonly Dictionary<IBuildingConfiguration, BuildingConstructionButtonMB> _buildingConstructionButtons = new();
        private readonly Dictionary<BuildingConstructionButtonMB, Action> _buttonActions = new();

        public bool TryAddConstructionButton(IBuildingConfiguration configuration)
        {
            if (_buildingConstructionButtons.TryAdd(configuration, null))
            {
                BuildingConstructionButtonMB button = _constructionButtonSpawner.SpawnButton();
                _buildingConstructionButtons[configuration] = button;
                button.DisplayBuildingConfiguration(configuration);

                BuildingConstructionConfiguration constructionConfiguration = new(configuration);
                Action action = _placingInvokeCreator.CreatePlacingInvoke(constructionConfiguration);
                _buttonActions.Add(button, action);
                button.OnButtonClicked += action;

                Debug.Log($"Building construction button added for configuration: {configuration}");

                return true;
            }

            return false;
        }

        public bool TryRemoveConstructionButton(IBuildingConfiguration configuration)
        {
            if (_buildingConstructionButtons.Remove(configuration, out var button))
            {
                if (_buttonActions.Remove(button, out Action action))
                {
                    button.OnButtonClicked -= action; //Not neccessary, probably. Will look into it later.
                    UnityEngine.Object.Destroy(button.gameObject);

                    Debug.Log($"Building construction button removed of configuration: {configuration}");

                    return true;
                }
            }

            return false;
        }

        private class BuildingConstructionConfiguration : IConstructionConfiguration
        {
            private readonly IBuildingConfiguration _buildingConfiguration;

            public BuildingConstructionConfiguration(IBuildingConfiguration buildingConfiguration)
            {
                _buildingConfiguration = buildingConfiguration ?? throw new ArgumentNullException(nameof(buildingConfiguration));
            }

            public HashSet<Vector2Int> OccupiedCells => _buildingConfiguration.OccupiedCells;
            public ConstructionPreviewMB ConstructionPreviewPrefab => _buildingConfiguration.ConstructionPreviewPrefab;

            public BuildingStructure CreateBuildingStructure()
            {
                Building building = _buildingConfiguration.CreateBuilding();

                return building.Structure;
            }
        }
    }
}