using BuildingViewSystem;
using ConstructionGridSystem;
using LayoutSystem;
using PlacingSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingConstructionButtonsManager : IBuildingConstructionButtonsManager
    {
        private readonly IBuildingConstructionButtonSpawner _constructionButtonSpawner;
        private readonly IInvokePlacingFactory _invokePlacingFactory;
        private readonly IStructureBuildingsManager _structureBuildingsManager;

        public BuildingConstructionButtonsManager(IBuildingConstructionButtonSpawner constructionButtonSpawner,
                                                  IInvokePlacingFactory invokePlacingFactory,
                                                  IStructureBuildingsManager structureBuildingsManager)
        {
            _constructionButtonSpawner = constructionButtonSpawner ?? throw new ArgumentNullException(nameof(constructionButtonSpawner));
            _invokePlacingFactory = invokePlacingFactory ?? throw new ArgumentNullException(nameof(invokePlacingFactory));
            _structureBuildingsManager = structureBuildingsManager ?? throw new ArgumentNullException(nameof(structureBuildingsManager));
        }

        private readonly Dictionary<IBuildingConfiguration, BuildingConstructionButtonMB> _buildings_ConstructionButtons = new();

        public bool TryAddConstructionButton(IBuildingConfiguration configuration)
        {
            if (_buildings_ConstructionButtons.TryAdd(configuration, null))
            {
                Action invokePlacing = _invokePlacingFactory.CreateInvokePlacing(configuration.Construction, CreateBuilding);

                BuildingConstructionButtonMB button = _constructionButtonSpawner.SpawnButton();
                button.DisplayBuildingConfiguration(configuration);
                button.OnButtonClicked += StartPlacing;

                _buildings_ConstructionButtons[configuration] = button;
                //Debug.Log($"Building construction button added for configuration: {configuration}");

                return true;

                void StartPlacing()
                {
                    //Following order is important
                    invokePlacing();
                    button.DisplayBuildingSelected();
                }

                void CreateBuilding(BuildingStructure structure)
                {
                    Building building = configuration.CreateBuilding(structure);
                    _structureBuildingsManager.TryAddStructureBuilding(building.Structure, building);
                }
            }

            return false;
        }

        public bool TryRemoveConstructionButton(IBuildingConfiguration configuration)
        {
            if (_buildings_ConstructionButtons.Remove(configuration, out var button))
            {
                UnityEngine.Object.Destroy(button.gameObject);
                //Debug.Log($"Building construction button removed of configuration: {configuration}");
                return true;
            }

            return false;
        }
    }
}