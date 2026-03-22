using UnityEngine;
using PlacingSystem;

namespace ConstructionUISystem
{
    public class ConstructionButtonsManagerMB : MonoBehaviour, IConstructionButtonsManager
    {
        [SerializeField] private ConstructionButtonSpawnerMB constructionButtonSpawner;
        [SerializeField] private PlacingInvokeCreatorMB placingInvokeCreator;

        private IConstructionButtonsManager _manager;

        private void Awake()
        {
            _manager = new ConstructionButtonsManager(constructionButtonSpawner, placingInvokeCreator);
        }

        public bool TryAddConstructionButton(IConstructionConfiguration construction)
        {
            return _manager.TryAddConstructionButton(construction);
        }

        public bool TryRemoveConstructionButton(IConstructionConfiguration construction)
        {
            return _manager.TryRemoveConstructionButton(construction);
        }
    }
}