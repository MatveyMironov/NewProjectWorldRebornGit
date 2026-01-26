using CustomUISystem;
using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class ManufactureProgressDisplayerMB : MonoBehaviour, IManufactureProgressDisplayer
    {
        [SerializeField] private ANumberDisplayerMB progressValueDisplayer;

        private IManufactureProgressDisplayer _displayer;

        private void Awake()
        {
            _displayer = new ManufactureProgressDisplayer(progressValueDisplayer);
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