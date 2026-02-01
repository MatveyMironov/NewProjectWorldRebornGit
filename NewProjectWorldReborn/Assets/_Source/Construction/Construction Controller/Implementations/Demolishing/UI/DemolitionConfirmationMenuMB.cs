using HidableSystem;
using UnityEngine;

namespace DemolishingSystem.UI
{
    public class DemolitionConfirmationMenuMB : MonoBehaviour
    {
        [SerializeField] private DemolitionControllerMB demolitionController;
        [SerializeField] private AHidableMB hidable;

        private void Start()
        {
            hidable.Hide();

            demolitionController.OnBuildingSelected += hidable.Show;
            demolitionController.OnBuildingDeselected += hidable.Hide;
        }

        private void OnDestroy()
        {
            demolitionController.OnBuildingSelected -= hidable.Show;
            demolitionController.OnBuildingDeselected -= hidable.Hide;
        }
    }
}