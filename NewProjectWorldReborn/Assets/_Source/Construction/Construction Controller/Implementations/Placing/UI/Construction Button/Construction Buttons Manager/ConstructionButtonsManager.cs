using ConstructionGridSystem;
using System;
using System.Collections.Generic;
using PlacingSystem;
using ConstructionConfigurationSystem;

namespace ConstructionUISystem
{
    public class ConstructionButtonsManager : IConstructionButtonsManager
    {
        private readonly IConstructionButtonSpawner _constructionButtonSpawner;
        private readonly IPlacingInvokeCreator _placingInvokeCreator;

        public ConstructionButtonsManager(IConstructionButtonSpawner constructionButtonSpawner, IPlacingInvokeCreator placingInvokeCreator)
        {
            _constructionButtonSpawner = constructionButtonSpawner ?? throw new ArgumentNullException(nameof(constructionButtonSpawner));
            _placingInvokeCreator = placingInvokeCreator ?? throw new ArgumentNullException(nameof(placingInvokeCreator));
        }

        private readonly Dictionary<IConstructionConfiguration, ConstructionButtonMB> _constructionButtons = new();
        private readonly Dictionary<ConstructionButtonMB, Action> _buttonActions = new();

        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<BuildingStructure> buildingPlacedCallback)
        {
            if (_constructionButtons.TryAdd(construction, null))
            {
                _constructionButtons[construction] = _constructionButtonSpawner.SpawnConstructionButton();

                if (_buttonActions.TryAdd(_constructionButtons[construction], null))
                {
                    _buttonActions[_constructionButtons[construction]] = _placingInvokeCreator.CreatePlacingInvoke(construction, buildingPlacedCallback);
                    _constructionButtons[construction].OnButtonClicked += _buttonActions[_constructionButtons[construction]];
                }

                return true;
            }

            return false;
        }

        public bool TryRemoveConstructionButton(IConstructionConfiguration construction)
        {
            if (_constructionButtons.Remove(construction, out var button))
            {
                if (_buttonActions.Remove(button, out Action action))
                {
                    button.OnButtonClicked -= action;
                }

                UnityEngine.Object.Destroy(button.gameObject);
                return true;
            }

            return false;
        }
    }
}