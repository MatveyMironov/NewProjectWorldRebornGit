using ConstructionGridSystem;
using UnityEngine;
using UnityEngine.Events;

namespace DemolishingSystem
{
    public class DemolishingDisplayerMB : MonoBehaviour
    {
        [SerializeField] private DemolishingInvokerMB demolishingInvoker;

        [Space]
        [SerializeField] private UnityEvent onStateEntered;
        [SerializeField] private UnityEvent onStateExited;
        [SerializeField] private UnityEvent<BuildingStructure> onStructureSelected;
        [SerializeField] private UnityEvent onStructureDeselected;

        private void Start()
        {
            demolishingInvoker.OnStateEntered += OnStateEntered;
            demolishingInvoker.OnStateExited += OnStateExited;
            demolishingInvoker.OnStructureSelected += OnStructureSelected;
            demolishingInvoker.OnStructureDeselected += OnStructureDeselected;
        }

        private void OnDestroy()
        {
            demolishingInvoker.OnStateEntered -= OnStateEntered;
            demolishingInvoker.OnStateExited -= OnStateExited;
            demolishingInvoker.OnStructureSelected -= OnStructureSelected;
            demolishingInvoker.OnStructureDeselected -= OnStructureDeselected;
        }

        private void OnStructureSelected()
        {
            onStructureSelected.Invoke(demolishingInvoker.SelectedStructure);
        }

        private void OnStructureDeselected()
        {
            onStructureDeselected.Invoke();
        }

        private void OnStateEntered()
        {
            onStateEntered.Invoke();
        }

        private void OnStateExited()
        {
            onStateExited.Invoke();
        }
    }
}