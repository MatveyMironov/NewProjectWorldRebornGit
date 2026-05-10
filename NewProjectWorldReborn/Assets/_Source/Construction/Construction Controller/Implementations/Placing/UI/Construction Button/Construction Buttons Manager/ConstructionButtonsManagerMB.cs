using ConstructionGridSystem;
using PlacingSystem;
using System;
using UnityEngine;

namespace ConstructionUISystem
{
    public class ConstructionButtonsManagerMB : MonoBehaviour, IConstructionButtonsManager
    {
        [SerializeField] private ConstructionButtonSpawnerMB constructionButtonSpawner;
        [SerializeField] private InvokePlacingFactoryMB placingInvokeCreator;

        private IConstructionButtonsManager _manager;

        private void Awake()
        {
            _manager = new ConstructionButtonsManager(constructionButtonSpawner, placingInvokeCreator);
        }

        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<BuildingStructure> structurePlacedCallback)
        {
            return _manager.TryAddConstructionButton(construction, structurePlacedCallback);
        }

        public bool TryRemoveConstructionButton(IConstructionConfiguration construction)
        {
            return _manager.TryRemoveConstructionButton(construction);
        }
    }
}