using ResourceSystem;
using StorageSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Resource Storage Task", menuName = "Progression/Task Configuration/Resource Storage Task")]
    public class ResourceStorageTaskConfigurationSO : ATaskConfigurationSO
    {
        [SerializeField] private ResourceDefinitionSO targetResource;
        [SerializeField] private int targetAmount;
        [SerializeField] private ResourceStorageTaskDisplayerMB displayerPrefab;

        public override ITask CreateTask()
        {
            return new ResourceStorageTask(targetResource, targetAmount, StorageSingleton.Instance, displayerPrefab);
        }
    }
}