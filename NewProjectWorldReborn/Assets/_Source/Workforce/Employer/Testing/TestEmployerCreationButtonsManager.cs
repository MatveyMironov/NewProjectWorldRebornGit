using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EmployerSystem.Testing
{

    public class TestEmployerCreationButtonsManager : MonoBehaviour
    {
        [SerializeField] private Button employerCreationButtonPrefab;
        [SerializeField] private RectTransform parent;

        private IEmployersManager _employersManager;

        private readonly Dictionary<SEmployerConfiguration, Button> _employerCreationButtons = new();

        private void Awake()
        {
            _employersManager = EmployersManagerSingleton.Instance;
        }

        public void AddEmployerConfiguration(SEmployerConfiguration configuration)
        {
            if (_employerCreationButtons.TryAdd(configuration, null))
            {
                _employerCreationButtons[configuration] = Instantiate(employerCreationButtonPrefab, parent);
                _employerCreationButtons[configuration].onClick.AddListener(CreateEmployer);
            }

            void CreateEmployer()
            {
                _employersManager.TryAddEmployer(configuration.GetEmployer());
            }
        }

        public void RemoveEmployerConfiguration(SEmployerConfiguration configuration)
        {
            if (_employerCreationButtons.Remove(configuration, out var button))
            {
                Destroy(button.gameObject);
            }
        }
    }
}