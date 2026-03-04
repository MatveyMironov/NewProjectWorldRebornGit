using UnityEngine;

namespace HidableSystem.Implementations
{
    public class CompositeHidableMB : AHidableMB
    {
        [SerializeField] private IHidable[] hidables;

        public override void Hide()
        {
            foreach (var hidable in hidables)
            {
                if (hidable == (IHidable)this)
                    continue;

                hidable.Hide();
            }
        }

        public override void Show()
        {
            foreach (var hidable in hidables)
            {
                if (hidable == (IHidable)this)
                    continue;

                hidable.Show();
            }
        }
    }
}