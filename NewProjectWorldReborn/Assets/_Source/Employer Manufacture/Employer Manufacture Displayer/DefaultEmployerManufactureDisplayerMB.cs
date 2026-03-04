using EmployerSystem;
using ManufactureSystem;
using UnityEngine;

namespace EmployerManufactureSystem
{
    public class DefaultEmployerManufactureDisplayerMB : AEmployerManufactureDisplayerMB
    {
        [SerializeField] private AEmployerDisplayerMB employerDisplayer;
        [SerializeField] private AManufactureDisplayerMB manufactureDisplayer;

        public override void DisplayEmployerManufacture(EmployerManufacture employerManufacture)
        {
            employerDisplayer.DisplayEmployer(employerManufacture.Employer);
            manufactureDisplayer.DisplayManufacture(employerManufacture.Manufacture);
        }

        public override void Clear()
        {
            employerDisplayer.Clear();
            manufactureDisplayer.Clear();
        }
    }
}