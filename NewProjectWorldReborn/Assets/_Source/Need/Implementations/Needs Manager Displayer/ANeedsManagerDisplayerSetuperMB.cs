using UnityEngine;

namespace NeedSystem.Implementations
{
    public abstract class ANeedsManagerDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private NeedsManagerDisplayerMB needsManagerDisplayer;

        protected abstract INeedsManager NeedsManager { get; }

        private void OnEnable()
        {
            needsManagerDisplayer.DisplayNeedsManager(NeedsManager);
        }

        private void OnDisable()
        {
            needsManagerDisplayer.Clear();
        }
    }
}