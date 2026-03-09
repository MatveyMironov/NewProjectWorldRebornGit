using System;
using UnityEngine;

namespace EmployerSystem
{
    [Serializable]
    public class SEmployerConfiguration
    {
        [SerializeField] private int minWorkForce;
        [SerializeField] private int maxWorkForce;

        public IEmployer GetEmployer()
        {
            return new Employer(minWorkForce, maxWorkForce);
        }
    }
}