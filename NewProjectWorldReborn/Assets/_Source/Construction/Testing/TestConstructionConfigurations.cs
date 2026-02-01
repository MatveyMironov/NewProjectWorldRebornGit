using ConstructionUISystem;
using UnityEngine;
using PlacingSystem;

namespace ConstructionSystem.Testing
{
    public class TestConstructionConfigurations : MonoBehaviour
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