using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem.NoArguments
{
    public class MultipleNoArgumentsGameEventsListener : MonoBehaviour, INoArgumentsGameEventListener
    {
        [SerializeField] private NoArgumentsGameEventSO[] gameEvents = new NoArgumentsGameEventSO[0];
        [Space]
        [SerializeField] private UnityEvent response;

        private void Awake()
        {
            foreach (var gameEvent in gameEvents)
            {
                gameEvent.AddListener(this);
            }
        }

        private void OnDestroy()
        {
            foreach (var gameEvent in gameEvents)
            {
                gameEvent.RemoveListener(this);
            }
        }

        public void Notify()
        {
            response.Invoke();
        }
    }
}