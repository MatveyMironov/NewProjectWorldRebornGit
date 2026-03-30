using EmployerSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class EmployerBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AEmployerDisplayerMB employerDisplayer;

        public override void DisplayBuilding(Building building)
        {
            IEmployer employer = building.Interior.Employer;

            if (employer == null)
            {
                Clear();
                return;
            }

            employerDisplayer.DisplayEmployer(employer);
        }

        public override void Clear()
        {
            employerDisplayer.Clear();
        }
    }
}