using UnityEngine;

namespace ManufactureSystem
{
    internal class ManufactureDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private ManufactureMB manufacture;
        [SerializeField] private AManufactureDisplayerMB displayer;

        private void Start()
        {
            displayer.DisplayManufacture(manufacture);
        }
    }
}