using ConstructionUISystem;
using PlacingSystem;
using UnityEngine;

namespace ConstructionSystem.Testing
{
    public class TestBuildingConstructionButtonsCreator : MonoBehaviour
    {
        [SerializeField] private ConstructionConfigurationSO[] constructionConfigurations = new ConstructionConfigurationSO[0];
        [SerializeField] private ConstructionButtonsManagerMB constructionButtonsManager;

        private void Start()
        {
            foreach (var configuration in constructionConfigurations)
            {
                constructionButtonsManager.TryAddConstructionButton(configuration);
            }
        }
    }
}