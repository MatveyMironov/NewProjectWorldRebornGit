using EmployerSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class ABuildingEmployerRegisterMB : MonoBehaviour
    {
        protected abstract IStructureBuildingsManager BuildingsManager { get; }
        protected abstract IEmployersManager EmployersManager { get; }

        protected virtual void Awake()
        {
            BuildingsManager.OnBuildingAdded += RegisterBuildingEmployerIfExistent;
            BuildingsManager.OnBuildingRemoved += UnregisterBuildingEmployerIfExistent;
        }

        protected virtual void OnDestroy()
        {
            BuildingsManager.OnBuildingAdded -= RegisterBuildingEmployerIfExistent;
            BuildingsManager.OnBuildingRemoved -= UnregisterBuildingEmployerIfExistent;
        }

        private void RegisterBuildingEmployerIfExistent(Building building)
        {
            IEmployer employer = building.Interior.Employer;

            if (employer == null) { return; }

            if (EmployersManager.TryAddEmployer(employer))
            {
                //Debug.Log("")
            }
        }

        private void UnregisterBuildingEmployerIfExistent(Building building)
        {
            IEmployer employer = building.Interior.Employer;

            if (employer == null) { return; }

            if (EmployersManager.TryRemoveEmployer(employer))
            {
                //Debug.Log("")
            }
        }
    }
}