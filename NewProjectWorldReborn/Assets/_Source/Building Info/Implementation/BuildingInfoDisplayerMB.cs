using TMPro;
using UnityEngine;

namespace BuildingInfoSystem.Implementation
{
    public class BuildingInfoDisplayerMB : ABuildingInfoDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI descriptionText;

        public override void DisplayBuildingInfo(IBuildingInfo info)
        {
            DisplayName(info.Name);
            DisplayDescription(info.Description);
        }

        public override void Clear()
        {
            ClearName();
            ClearDescription();
        }

        private void DisplayName(string name)
        {
            nameText.text = name;
        }

        private void ClearName()
        {
            DisplayName(string.Empty);
        }

        private void DisplayDescription(string description)
        {
            descriptionText.text = description;
        }

        private void ClearDescription()
        {
            DisplayDescription(string.Empty);
        }
    }
}