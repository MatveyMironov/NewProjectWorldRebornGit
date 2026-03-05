using EmployerSystem;
using ResourceSystem;
using System;
using UnityEngine;

namespace EmployerManufactureSystem
{
    [Serializable]
    public class SEmployerManufactureConfiguration : IEmployerManufactureConfiguration
    {
        [SerializeField] private SResourceCountsDictionary consumedResources;
        [SerializeField] private SResourceCountsDictionary producedResources;
        [SerializeField] private int maxTime;
        [SerializeField] private SEmployerConfiguration employerConfiguration;

        public IEmployerManufacture CreateEmployerManufacture()
        {
            IEmployer employer = employerConfiguration.GetEmployer();
            return new EmployerManufacture(consumedResources.GetResourceCountsDictionary(), producedResources.GetResourceCountsDictionary(), maxTime, employer);
        }
    }
}