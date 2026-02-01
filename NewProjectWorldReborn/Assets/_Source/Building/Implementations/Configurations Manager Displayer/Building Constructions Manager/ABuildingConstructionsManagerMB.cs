using BuildingConstructionUISystem;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingConstructionsManagerMB : MonoBehaviour, IBuildingConstructionsManager
    {
        [SerializeField] private BuildingConstructionButtonsManagerMB constructionButtonsManager;

        protected abstract IStructureBuildingsManager ConstructedBuildingCorrespondancesManager { get; }

        private IBuildingConstructionsManager _manager;

        protected virtual void Awake()
        {
            _manager = new BuildingConstructionsManager(ConstructedBuildingCorrespondancesManager, constructionButtonsManager);
        }

        public bool TryAddBuildingConstruction(IBuildingConfiguration configuration)
        {
            return _manager.TryAddBuildingConstruction(configuration);
        }

        public bool TryRemoveBuildingConstruction(IBuildingConfiguration configuration)
        {
            return _manager.TryRemoveBuildingConstruction(configuration);
        }
    }
}