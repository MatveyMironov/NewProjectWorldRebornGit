using ServiceSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Service Task", menuName = "Progression/Task Configuration/Service Task")]
    public class ServiceTaskConfigurationSO : ATaskConfigurationSO
    {
        [SerializeField] private ServiceDefinitionSO requiredService;
        [SerializeField] private int requiredAmount;
        [SerializeField] private ServiceTaskDisplayerMB displayerPrefab;

        public override ITask CreateTask()
        {
            SuppliesManager serviceBalance = ServicesManagerSingleton.Instance.GetServiceSupply(requiredService);
            return new ServiceTask(requiredService, requiredAmount, serviceBalance, displayerPrefab);
        }
    }
}