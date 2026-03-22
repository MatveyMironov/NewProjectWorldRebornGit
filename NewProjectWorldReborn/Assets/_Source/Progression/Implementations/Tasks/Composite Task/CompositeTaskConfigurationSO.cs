using System.Collections.Generic;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Composite Task", menuName = "Progression/Task Configuration/Composite Task")]
    public class CompositeTaskConfigurationSO : ATaskConfigurationSO
    {
        [SerializeField] private ATaskConfigurationSO[] partConfigurations = new ATaskConfigurationSO[0];
        [SerializeField] private CompositeTaskDisplayerMB displayerPrefab;

        public ITaskConfiguration[] SecuredParts => SecureParts(partConfigurations);

        public override ITask CreateTask()
        {
            List<ITask> tasks = new();

            foreach (ITaskConfiguration part in SecuredParts)
            {
                AddTask(part);
            }

            return new CompositeTask(tasks.ToArray(), displayerPrefab);

            void AddTask(ITaskConfiguration configuration)
            {
                if (configuration is CompositeTaskConfigurationSO composite)
                {
                    AddCompositeTask(composite);
                    return;
                }

                tasks.Add(configuration.CreateTask());
            }

            void AddCompositeTask(CompositeTaskConfigurationSO composite)
            {
                foreach (ITaskConfiguration part in SecureParts(composite.SecuredParts))
                {
                    tasks.Add(part.CreateTask());
                }
            }
        }

        private ITaskConfiguration[] SecureParts(ITaskConfiguration[] parts)
        {
            List<ITaskConfiguration> secureParts = new();

            foreach (ITaskConfiguration part in parts)
            {
                if ((object)part == this)
                {
                    Debug.Log($"ERROR! Composite task [{name}] contains itself as a composite part. It will be removed.");
                    continue;
                }

                secureParts.Add(part);
            }

            return secureParts.ToArray();
        }
    }
}