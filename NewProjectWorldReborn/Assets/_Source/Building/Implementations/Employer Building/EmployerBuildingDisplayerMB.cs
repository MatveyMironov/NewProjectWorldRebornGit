using EmployerSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class EmployerBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AEmployerDisplayerMB employerDisplayer;

        private readonly IBuildingEmployersManager _buildingEmployersManager = BuildingEmployersManagerSingleton.Instance;

        public override void DisplayBuilding(Building building)
        {
            if (_buildingEmployersManager.TryGetBuildingEmployer(building, out IEmployer employer))
            {
                employerDisplayer.DisplayEmployer(employer);
            }
            else
            {
                Clear();
            }
        }

        public override void Clear()
        {
            employerDisplayer.Clear();
        }
    }
}