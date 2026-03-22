using HidableSystem;
using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class HidableResourceDisplayerMB : AResourceDisplayerMB
    {
        [SerializeField] private AHidableMB hidable;
        [SerializeField] private AResourceDisplayerMB resourceDisplayer;

        private void Start()
        {
            Clear();
        }

        public override void DisplayResource(IResourceDefinition resource)
        {
            resourceDisplayer.DisplayResource(resource);
            hidable.Show();
        }

        public override void Clear()
        {
            resourceDisplayer.Clear();
            hidable.Hide();
        }
    }
}