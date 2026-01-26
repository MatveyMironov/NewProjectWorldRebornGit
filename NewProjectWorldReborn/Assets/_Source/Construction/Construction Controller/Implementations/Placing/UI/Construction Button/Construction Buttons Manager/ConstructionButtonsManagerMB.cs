using ConstructionGridSystem;
using System;
using UnityEngine;
using PlacingSystem;
using ConstructionConfigurationSystem;

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

        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<BuildingStructure> buildingPlacedCallback)
        {
            return _manager.TryAddConstructionButton(construction, buildingPlacedCallback);
        }

        public bool TryRemoveConstructionButton(IConstructionConfiguration construction)
        {
            return _manager.TryRemoveConstructionButton(construction);
        }
    }
}