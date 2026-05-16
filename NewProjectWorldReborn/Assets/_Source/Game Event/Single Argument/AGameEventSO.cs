using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    //[CreateAssetMenu(fileName = "New <Type> Game Event", menuName = "Game Event/<Type>")]
    public abstract class AGameEventSO<T> : ScriptableObject
    {
        private readonly List<AGameEventListenerMB<T>> _listeners = new();

        public void AddListener(AGameEventListenerMB<T> listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(AGameEventListenerMB<T> listener)
        {
            _listeners.Remove(listener);
        }

        public void Call(T data)
        {
            foreach (AGameEventListenerMB<T> listener in _listeners)
            {
                listener.Notify(data);
            }
        }
    }
}