using HidableSystem;
using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class HidableManufactureDisplayerMB : AManufactureDisplayerMB
    {
        [SerializeField] private AManufactureDisplayerMB actualDisplayer;
        [SerializeField] private AHidableMB hidable;

        public override void DisplayManufacture(IManufacture manufacture)
        {
            actualDisplayer.DisplayManufacture(manufacture);
            hidable.Show();
        }

        public override void Clear()
        {
            actualDisplayer.Clear();
            hidable.Hide();
        }
    }
}