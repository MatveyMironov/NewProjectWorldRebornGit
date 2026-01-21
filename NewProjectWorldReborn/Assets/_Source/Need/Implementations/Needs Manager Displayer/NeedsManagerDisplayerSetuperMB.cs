using UnityEngine;

namespace NeedSystem.Implementations
{
    public class NeedsManagerDisplayerSetuperMB : ANeedsManagerDisplayerSetuperMB
    {
        [SerializeField] private NeedsManagerMB needsManager;

        protected override INeedsManager NeedsManager => needsManager;
    }
}