using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EmployerSystem.Testing
{
    public class TestEmployerSelectionButtonsManagerMB : MonoBehaviour
    {
        [SerializeField] private Button employerSelectionButtonPrefab;
        [SerializeField] private RectTransform root;

        [Space]
        [SerializeField] private AEmployerDisplayerMB employerDisplayer;

        private readonly Dictionary<IEmployer, Button> _employerSelectionButtons = new();

        public void AddEmployer(IEmployer employer)
        {
            if (_employerSelectionButtons.TryAdd(employer, null))
            {
                _employerSelectionButtons[employer] = Instantiate(employerSelectionButtonPrefab, root);
                _employerSelectionButtons[employer].onClick.AddListener(SelectEmployer);
            }

            void SelectEmployer()
            {
                employerDisplayer.DisplayEmployer(employer);
            }
        }

        public void RemoveEmployer(IEmployer employer)
        {
            if (_employerSelectionButtons.Remove(employer, out var button))
            {
                Destroy(button.gameObject);
            }
        }
    }
}