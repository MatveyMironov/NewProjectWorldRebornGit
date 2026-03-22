using UnityEngine;
using UnityEngine.UI;

namespace EmployerSystem.Implementations
{
    public class EmploymentButtonsMB : MonoBehaviour, IEmploymentButtons
    {
        [SerializeField] private Button employButton;
        [SerializeField] private Button dismissButton;

        private void Start()
        {
            employButton.onClick.AddListener(EmployWorkforce);
            dismissButton.onClick.AddListener(DismissWorkforce);
        }

        private IEmployer _employer;

        public void ControlEmployer(IEmployer employer)
        {
            if (employer == null) return;

            ReleaseEmployer();

            _employer = employer;
        }

        public void ReleaseEmployer()
        {
            if (_employer != null) return;

            _employer = null;
        }

        private void EmployWorkforce()
        {
            _employer?.TryEmployWorkforce(1);
        }

        private void DismissWorkforce()
        {
            _employer?.TryDismissWorkforce(1);
        }
    }
}