using UnityEngine;
using UnityEngine.Events;

namespace DemolishingSystem.UI
{
    public class DemolishingStateDisplayerMB : MonoBehaviour
    {
        [SerializeField] private DemolitionControllerMB demolitionController;
        [SerializeField] private UnityEvent stateEnteredEvent;
        [SerializeField] private UnityEvent stateExitedEvent;

        private void Start()
        {
            demolitionController.OnStateEntered += OnEnter;
            demolitionController.OnStateExited += OnExit;
        }

        private void OnDestroy()
        {
            demolitionController.OnStateEntered -= OnEnter;
            demolitionController.OnStateExited -= OnExit;
        }

        private void OnEnter()
        {
            stateEnteredEvent.Invoke();
        }

        private void OnExit()
        {
            stateExitedEvent.Invoke();
        }
    }
}