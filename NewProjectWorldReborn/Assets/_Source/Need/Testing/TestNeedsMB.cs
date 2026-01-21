using UnityEngine;

namespace NeedSystem.Testing
{
    public class TestNeedsMB : ATestNeedsMB
    {
        [Space]
        [SerializeField] private NeedsManagerMB needsManager;

        protected override INeedsManager NeedsManager => needsManager;
    }
}