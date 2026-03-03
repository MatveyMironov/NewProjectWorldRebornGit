using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EmployerSystem.Testing
{
    public class TestEmployersManagerDisplayerMB : MonoBehaviour
    {
        [SerializeField] private AEmployerDisplayerMB employerDisplayerPrefab;
        [SerializeField] private Transform parent;

        private IEmployersManager _displayedManager;

        private readonly Dictionary<IEmployer, AEmployerDisplayerMB> _employers_displayers = new();

        private void Start()
        {
            DisplayEmployersManager(EmployersManagerSingleton.Instance);
        }

        private void OnDestroy()
        {
            Clear();
        }

        private void DisplayEmployersManager(IEmployersManager manager)
        {
            Clear();
            _displayedManager = manager;

            manager.OnEmployerAdded += DisplayEmployer;
            manager.OnEmployerRemoved += HideEmployer;

            foreach (var employer in manager.Employers)
            {
                DisplayEmployer(employer);
            }
        }

        private void Clear()
        {
            if (_displayedManager == null) return;

            _displayedManager.OnEmployerAdded -= DisplayEmployer;
            _displayedManager.OnEmployerRemoved -= HideEmployer;

            foreach(var employer in _employers_displayers.Keys.ToArray())
            {
                HideEmployer(employer);
            }

            _displayedManager = null;
        }

        private void DisplayEmployer(IEmployer employer)
        {
            if (_employers_displayers.TryAdd(employer, null))
            {
                _employers_displayers[employer] = Instantiate(employerDisplayerPrefab, parent);
                _employers_displayers[employer].DisplayEmployer(employer);
            }
        }

        private void HideEmployer(IEmployer employer)
        {
            if (_employers_displayers.Remove(employer, out var displayer))
            {
                Destroy(displayer.gameObject);
            }
        }
    }
}