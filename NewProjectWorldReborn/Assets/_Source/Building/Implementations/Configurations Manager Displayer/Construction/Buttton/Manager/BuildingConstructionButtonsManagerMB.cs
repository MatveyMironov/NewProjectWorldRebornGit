using ConstructionResourcesSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingConstructionButtonsManagerMB : MonoBehaviour, IBuildingConstructionButtonsManager
    {
        [SerializeField] private BuildingConstructionButtonSpawnerMB constructionButtonSpawner;
        [SerializeField] private InvokeConstructionResourcesPlacingFactoryMB invokePlacingFactory;

        private IBuildingConstructionButtonsManager _manager;

        private void Awake()
        {
            _manager = new BuildingConstructionButtonsManager(constructionButtonSpawner, invokePlacingFactory, StructureBuildingsManagerSingleton.Instance); //TODO: Create abstraction?
        }

        public bool TryAddConstructionButton(IBuildingConfiguration configuration)
        {
            return _manager.TryAddConstructionButton(configuration);
        }

        public bool TryRemoveConstructionButton(IBuildingConfiguration configuration)
        {
            return _manager.TryRemoveConstructionButton(configuration);
        }
    }
}