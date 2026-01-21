using UnityEngine;

namespace NeedSystem.Testing
{
    public abstract class ATestNeedsMB : MonoBehaviour
    {
        [SerializeField] private ANeedConfigurationSO[] needs = new ANeedConfigurationSO[0];

        protected abstract INeedsManager NeedsManager { get; }

        private void Start()
        {
            foreach (var configuration in needs)
            {
                NeedsManager.TryAddNeed(configuration.CreateNeed());
            }
        }
    }
}