using BuildingSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Building Task", menuName = "Progression/Task Configuration/Building Task")]
    public class BuildingTaskConfigurationSO : ATaskConfigurationSO
    {
        [SerializeField] private ABuildingConfigurationSO requiredBuildingConfiguration;
        [SerializeField] private int requiredCount;
        [SerializeField] private BuildingTaskDisplayerMB displayerPrefab;

        public override ITask CreateTask()
        {
            return new BuildingTask(requiredBuildingConfiguration, requiredCount, ConfigurationBuildingsManagerSingleton.Instance, displayerPrefab);
        }
    }
}