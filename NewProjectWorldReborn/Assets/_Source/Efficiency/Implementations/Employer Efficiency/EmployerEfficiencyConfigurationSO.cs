using EmployerSystem;
using UnityEngine;

namespace EfficiencySystem.Implementations
{
    [CreateAssetMenu(fileName = "New Employer Efficiency", menuName = "Efficiency Configuration/Employer Efficiency")]
    public class EmployerEfficiencyConfigurationSO : AEfficiencyConfigurationSO
    {
        [SerializeField] private SEmployerConfiguration employerConfiguration;

        public override IEfficiency GetEfficiency()
        {
            IEmployer employer = employerConfiguration.GetEmployer();
            EmployersManagerSingleton.Instance.TryAddEmployer(employer);
            return new EmployerEfficiency(employer);
        }
    }
}