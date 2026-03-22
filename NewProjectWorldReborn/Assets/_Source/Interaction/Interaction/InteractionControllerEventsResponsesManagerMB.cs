using UnityEngine;
using UnityEngine.Events;

namespace InteractionSystem
{
    public class InteractionControllerEventsResponsesManagerMB : MonoBehaviour
    {
        [SerializeField] private InteractionControllerMB interactionController;
        [SerializeField] private UnityEvent<IInteractable> interactionSucceededResponse;
        [SerializeField] private UnityEvent interactionFailedResponse;

        private void OnEnable()
        {
            interactionController.OnInteractionSucceeded += interactionSucceededResponse.Invoke;
            interactionController.OnInteractionFailed += interactionFailedResponse.Invoke;
        }

        private void OnDisable()
        {
            interactionController.OnInteractionSucceeded -= interactionSucceededResponse.Invoke;
            interactionController.OnInteractionFailed -= interactionFailedResponse.Invoke;
        }
    }
}