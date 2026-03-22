using UnityEngine;

namespace ProgressionSystem.Testing
{
    [CreateAssetMenu(fileName = "New Test Task", menuName = "Progression/Task Configuration/Test Task")]
    public class TestTaskConfigurationSO : ATaskConfigurationSO
    {
        [SerializeField] private TestTaskDisplayerMB displayerPrefab;

        public override ITask CreateTask()
        {
            return new TestTask(name, displayerPrefab);
        }
    }
}