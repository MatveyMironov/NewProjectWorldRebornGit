using HidableSystem;
using UnityEngine;

namespace EmployerSystem.Implementations
{
    public class HidableEmployerDisplayerMB : AEmployerDisplayerMB
    {
        [SerializeField] private AEmployerDisplayerMB actualDisplayer;
        [SerializeField] private AHidableMB hidable;

        public override void DisplayEmployer(IEmployer employer)
        {
            actualDisplayer.DisplayEmployer(employer);
            hidable.Show();
        }

        public override void Clear()
        {
            actualDisplayer.Clear();
            hidable.Hide();
        }
    }
}