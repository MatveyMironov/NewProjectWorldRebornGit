using UnityEngine;

namespace EmployerSystem.Testing
{
    public class TestEmployersMB : MonoBehaviour
    {
        [SerializeField] private SEmployerConfiguration[] employerConfigurations = new SEmployerConfiguration[0];

        [Space]
        [SerializeField] private TestEmployerCreationButtonsManager creationButtonsManager;

        private void Start()
        {
            foreach (var configuration in employerConfigurations)
            {
                creationButtonsManager.AddEmployerConfiguration(configuration);
            }
        }
    }
}