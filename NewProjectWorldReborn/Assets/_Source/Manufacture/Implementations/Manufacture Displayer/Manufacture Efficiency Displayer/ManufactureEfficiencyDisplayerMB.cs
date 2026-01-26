using CustomUISystem;
using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class ManufactureEfficiencyDisplayerMB : MonoBehaviour, IManufactureEfficiencyDisplayer
    {
        [SerializeField] private ANumberDisplayerMB efficiencyValueDisplayer;

        private IManufactureEfficiencyDisplayer _displayer;

        private void Awake()
        {
            _displayer = new ManufactureEfficiencyDisplayer(efficiencyValueDisplayer);
        }

        public void DisplayManufacture(IManufacture manufacture)
        {
            _displayer.DisplayManufacture(manufacture);
        }

        public void Clear()
        {
            _displayer.Clear();
        }
    }
}