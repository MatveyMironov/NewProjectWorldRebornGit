using ConstructionGridSystem;
using PlacingSystem;
using System;
using System.Collections.Generic;

namespace ConstructionUISystem
{
    public class ConstructionButtonsManager : IConstructionButtonsManager
    {
        private readonly IConstructionButtonSpawner _constructionButtonSpawner;
        private readonly IInvokePlacingFactory _placingInvokeCreator;

        public ConstructionButtonsManager(IConstructionButtonSpawner constructionButtonSpawner, IInvokePlacingFactory placingInvokeCreator)
        {
            _constructionButtonSpawner = constructionButtonSpawner ?? throw new ArgumentNullException(nameof(constructionButtonSpawner));
            _placingInvokeCreator = placingInvokeCreator ?? throw new ArgumentNullException(nameof(placingInvokeCreator));
        }

        private readonly Dictionary<IConstructionConfiguration, ConstructionButtonMB> _constructionButtons = new();

        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<BuildingStructure> structurePlacedCallback)
        {
            if (_constructionButtons.TryAdd(construction, null))
            {
                _constructionButtons[construction] = _constructionButtonSpawner.SpawnConstructionButton();
                _constructionButtons[construction].OnButtonClicked += _placingInvokeCreator.CreateInvokePlacing(construction, structurePlacedCallback);

                return true;
            }

            return false;
        }

        public bool TryRemoveConstructionButton(IConstructionConfiguration construction)
        {
            if (_constructionButtons.Remove(construction, out var button))
            {
                UnityEngine.Object.Destroy(button.gameObject);
                return true;
            }

            return false;
        }
    }
}