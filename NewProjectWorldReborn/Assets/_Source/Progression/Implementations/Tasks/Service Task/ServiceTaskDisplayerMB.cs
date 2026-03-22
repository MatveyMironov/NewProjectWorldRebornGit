using CustomUISystem;
using ServiceSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class ServiceTaskDisplayerMB : MonoBehaviour
    {
        [SerializeField] private AServiceDefinitionDisplayerMB serviceDisplayer;
        [SerializeField] private ANumberDisplayerMB requiredAmountDisplayer;
        [SerializeField] private ANumberDisplayerMB supplyDisplayer;

        private ServiceTask _displayedTask;

        private void OnDestroy()
        {
            Clear();
        }

        public void DisplayServiceTask(ServiceTask task)
        {
            Clear();

            DisplayService(task.RequiredService);
            DisplayRequiredAmount(task.RequiredAmount);

            task.OnSupplyChanged += DisplayTaskSupply;
            DisplaySupply(task.Supply);

            _displayedTask = task;
        }

        public void Clear()
        {
            if (_displayedTask == null) return;

            serviceDisplayer.Clear();
            DisplayRequiredAmount(0);

            _displayedTask.OnSupplyChanged -= DisplayTaskSupply;
            DisplaySupply(0);

            _displayedTask = null;
        }

        private void DisplayTaskSupply()
        {
            DisplaySupply(_displayedTask.Supply);
        }

        private void DisplaySupply(int suppliedAmount)
        {
            supplyDisplayer.DisplayNumber(suppliedAmount);
        }

        private void DisplayRequiredAmount(int requiredAmount)
        {
            requiredAmountDisplayer.DisplayNumber(requiredAmount);
        }

        private void DisplayService(IServiceDefinition service)
        {
            serviceDisplayer.DisplayServiceDefinition(service);
        }
    }
}