using EmployerSystem;
using ManufactureSystem;
using ResourceSystem;
using System;
using System.Collections.Generic;

namespace EmployerManufactureSystem
{
    public class EmployerManufacture : IEmployerManufacture
    {
        private readonly EmployerManufactureParameters _parameters;

        public IEmployer Employer { get; }
        public IManufacture Manufacture { get; }

        public EmployerManufacture(Dictionary<IResourceDefinition, int> consumedResources,
                                   Dictionary<IResourceDefinition, int> producedResources,
                                   float maxSpeed,
                                   IEmployer employer)
        {
            Employer = employer ?? throw new ArgumentNullException(nameof(employer));
            _parameters = new(consumedResources, producedResources, maxSpeed, employer);
            Manufacture = new Manufacture(_parameters);
        }

        private class EmployerManufactureParameters : IManufactureParameters
        {
            private readonly float _maxSpeed;

            private readonly IEmployer _employer;

            public EmployerManufactureParameters(Dictionary<IResourceDefinition, int> consumedResources,
                                                 Dictionary<IResourceDefinition, int> producedResources,
                                                 float maxSpeed,
                                                 IEmployer employer)
            {
                ConsumedResources = consumedResources ?? throw new ArgumentNullException(nameof(consumedResources));
                ProducedResources = producedResources ?? throw new ArgumentNullException(nameof(producedResources));
                _maxSpeed = maxSpeed < 0 ? throw new ArgumentOutOfRangeException("Min time can't be less then 0") : 0;

                _employer = employer ?? throw new ArgumentNullException(nameof(employer));
            }

            public Dictionary<IResourceDefinition, int> ConsumedResources { get; }
            public Dictionary<IResourceDefinition, int> ProducedResources { get; }

            public float Speed => CalculateSpeed();
            public event Action OnManufactureTimeChanged { add => _employer.OnEmployedWorkforceChanged += value; remove => _employer.OnEmployedWorkforceChanged -= value; }

            private float CalculateSpeed()
            {
                float efficiency = (float)_employer.EmployedWorkforce / _employer.MaxWorkforce;
                float speed = _maxSpeed * efficiency;
                return speed;
            }
        }
    }
}