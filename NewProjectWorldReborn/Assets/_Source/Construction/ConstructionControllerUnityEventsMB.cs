using ConstructionControllerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace ConstructionSystem
{
    public class ConstructionControllerUnityEventsMB : MonoBehaviour
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [SerializeField] private UnityEvent OnStateEntered;
        [SerializeField] private UnityEvent OnStateExited;

        private void Start()
        {
            constructionController.OnStateEntered += OnStateEntered.Invoke;
            constructionController.OnStateExited += OnStateExited.Invoke;
        }

        private void OnDestroy()
        {
            constructionController.OnStateEntered -= OnStateEntered.Invoke;
            constructionController.OnStateExited -= OnStateExited.Invoke;
        }
    }
}