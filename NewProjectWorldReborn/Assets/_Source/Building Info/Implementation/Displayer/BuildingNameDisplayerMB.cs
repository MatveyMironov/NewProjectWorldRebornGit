using TMPro;
using UnityEngine;

namespace BuildingInfoSystem.Implementation
{
    public class BuildingNameDisplayerMB : ABuildingInfoDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI nameText;

        public override void DisplayBuildingInfo(IBuildingInfo info)
        {
            DisplayName(info.Name);
        }

        public override void Clear()
        {
            ClearName();

            void ClearName()
            {
                DisplayName(string.Empty);
            }
        }

        private void DisplayName(string name)
        {
            nameText.text = name;
        }
    }
}