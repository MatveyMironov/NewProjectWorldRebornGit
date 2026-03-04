using System;
using TMPro;
using UnityEngine;

namespace EmployerSystem.Implementations
{
    public class EmployerDisplayerMB : AEmployerDisplayerMB
    {
        [SerializeField] private EmploymentButtonsMB employmentButtons;
        [SerializeField] private TextMeshProUGUI workforceText;

        private EmploymentDisplayer _employmentDisplayer;

        private void Awake()
        {
            _employmentDisplayer = new EmploymentDisplayer(workforceText);
        }

        public override void DisplayEmployer(IEmployer employer)
        {
            Clear();

            employmentButtons.ControlEmployer(employer);
            _employmentDisplayer.DisplayEmployer(employer);
        }

        public override void Clear()
        {
            employmentButtons.ReleaseEmployer();
            _employmentDisplayer.Clear();
        }

        private class EmploymentDisplayer
        {
            private readonly TextMeshProUGUI _workforceText;

            public EmploymentDisplayer(TextMeshProUGUI workforceText)
            {
                _workforceText = workforceText != null ? workforceText : throw new ArgumentNullException(nameof(workforceText));
            }

            private IEmployer _displayedEmployer;

            private int _employedWorkforce;
            private int _maxWorkforce;

            public void DisplayEmployer(IEmployer employer)
            {
                Clear();

                DisplayMaxWorkforce(employer.MaxWorkforce);
                DisplayEmployedWorkforce(employer.EmployedWorkforce);
                employer.OnEmployedWorkforceChanged += DisplayEmployerEmployedWorkforce;

                _displayedEmployer = employer;
            }

            public void Clear()
            {
                if (_displayedEmployer == null) return;

                DisplayMaxWorkforce(0);
                _displayedEmployer.OnEmployedWorkforceChanged -= DisplayEmployerEmployedWorkforce;
                DisplayEmployedWorkforce(0);

                _displayedEmployer = null;
            }

            private void DisplayMaxWorkforce(int maxWorkforce)
            {
                _maxWorkforce = maxWorkforce;
                DisplayWorkforce();
            }

            private void DisplayEmployedWorkforce(int employedWorkforce)
            {
                _employedWorkforce = employedWorkforce;
                DisplayWorkforce();
            }

            private void DisplayEmployerMaxWorkforce()
            {
                DisplayMaxWorkforce(_displayedEmployer.MaxWorkforce);
            }

            private void DisplayEmployerEmployedWorkforce()
            {
                DisplayEmployedWorkforce(_displayedEmployer.EmployedWorkforce);
            }

            private void DisplayWorkforce()
            {
                _workforceText.text = $"{_employedWorkforce}/{_maxWorkforce}";
            }
        }
    }
}