using BuildingSystem;
using PlacingSystem;
using UnityEngine;

namespace BuildingConstructionUISystem
{
    public class BuildingConstructionButtonsManagerMB : MonoBehaviour, IBuildingConstructionButtonsManager
    {
        [SerializeField] private BuildingConstructionButtonSpawnerMB constructionButtonSpawner;
        [SerializeField] private PlacingInvokeCreatorMB placingInvokeCreator;

        private IBuildingConstructionButtonsManager _manager;

        private void Awake()
        {
            _manager = new BuildingConstructionButtonsManager(constructionButtonSpawner, placingInvokeCreator);
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