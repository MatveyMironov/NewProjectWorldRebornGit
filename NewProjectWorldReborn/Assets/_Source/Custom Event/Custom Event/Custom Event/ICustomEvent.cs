using System;

namespace CustomEventSystem
{
    public interface ICustomEvent
    {
        public void AddListener(Action listener);
        public void RemoveListener(Action listener);
        public void Call();
    }
}