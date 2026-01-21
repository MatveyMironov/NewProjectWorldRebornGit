using System;

namespace NeedSystem
{
    public interface INeed
    {
        public string Name { get; }

        public float Satisfaction { get; }
        public event Action OnSatisfactionChanged;
    }
}