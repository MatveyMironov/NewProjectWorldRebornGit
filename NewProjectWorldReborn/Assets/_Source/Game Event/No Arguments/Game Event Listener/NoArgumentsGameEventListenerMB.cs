using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem.NoArguments
{
    public class NoArgumentsGameEventListenerMB : MonoBehaviour, INoArgumentsGameEventListener
    {
        [SerializeField] private NoArgumentsGameEventSO gameEvent;
        [Space]
        [SerializeField] private UnityEvent response;

        private void Awake()
        {
            gameEvent.AddListener(this);
        }

        private void OnDestroy()
        {
            gameEvent.RemoveListener(this);
        }

        public void Notify()
        {
            response.Invoke();
        }
    }
}