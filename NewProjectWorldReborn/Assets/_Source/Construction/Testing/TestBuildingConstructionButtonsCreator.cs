using ConstructionGridSystem;
using ConstructionUISystem;
using UnityEngine;
using ConstructionConfigurationSystem;

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
                constructionButtonsManager.TryAddConstructionButton(configuration, DebugLog);

                void DebugLog(ConstructedBuilding building)
                {
                    Debug.Log($"Building {building} was constructed from configuration {configuration}");
                }
            }
        }
    }
}