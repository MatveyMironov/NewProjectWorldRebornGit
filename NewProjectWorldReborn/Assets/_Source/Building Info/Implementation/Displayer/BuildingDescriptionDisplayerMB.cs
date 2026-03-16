using TMPro;
using UnityEngine;

namespace BuildingInfoSystem.Implementation
{
    public class BuildingDescriptionDisplayerMB : ABuildingInfoDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI buildingDescriptionText;

        public override void DisplayBuildingInfo(IBuildingInfo info)
        {
            buildingDescriptionText.text = info.Description;
        }

        public override void Clear()
        {
            buildingDescriptionText.text = string.Empty;
        }
    }
}