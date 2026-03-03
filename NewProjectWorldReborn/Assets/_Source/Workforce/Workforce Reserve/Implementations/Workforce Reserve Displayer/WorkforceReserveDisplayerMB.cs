using CustomUISystem;
using TMPro;
using UnityEngine;

namespace WorkforceReserveSystem.Implementations
{
    public class WorkforceReserveDisplayerMB : MonoBehaviour, IWorkforceReserveDisplayer
    {
        [SerializeField] private ANumberDisplayerMB totalWorkforceDisplayer;
        [SerializeField] private ANumberDisplayerMB availableWorkforceDisplayer;
        [SerializeField] private ANumberDisplayerMB involvedWorkforceDisplayer;

        private IWorkforceReserve _displayedReserve;

        public void DisplayReserve(IWorkforceReserve reserve)
        {
            Clear();
            _displayedReserve = reserve;

            reserve.OnTotalWorkforceChanged += DisplayReserveTotalWorkforce;
            DisplayTotalWorkforce(reserve.TotalWorkforce);

            reserve.OnAvailableWorkforceChanged += DisplayReserveAvailableWorkforce;
            DisplayAvailableWorkforce(reserve.AvailableWorkforce);

            reserve.OnInvolvedWorkforceChanged += DisplayReserveInvolvedWorkforce;
            DisplayInvolvedWorkforce(reserve.InvolvedWorkforce);
        }

        public void Clear()
        {
            if (_displayedReserve == null) return;

            _displayedReserve.OnTotalWorkforceChanged -= DisplayReserveTotalWorkforce;
            DisplayTotalWorkforce(0);

            _displayedReserve.OnAvailableWorkforceChanged -= DisplayReserveAvailableWorkforce;
            DisplayAvailableWorkforce(0);

            _displayedReserve.OnInvolvedWorkforceChanged -= DisplayReserveInvolvedWorkforce;
            DisplayInvolvedWorkforce(0);

            _displayedReserve = null;
        }

        private void DisplayReserveTotalWorkforce()
        {
            DisplayTotalWorkforce(_displayedReserve.TotalWorkforce);
        }

        private void DisplayReserveAvailableWorkforce()
        {
            DisplayAvailableWorkforce(_displayedReserve.AvailableWorkforce);
        }

        private void DisplayReserveInvolvedWorkforce()
        {
            DisplayInvolvedWorkforce(_displayedReserve.InvolvedWorkforce);
        }

        private void DisplayTotalWorkforce(int totalWorkforce)
        {
            totalWorkforceDisplayer.DisplayNumber(totalWorkforce);
        }

        private void DisplayAvailableWorkforce(int availableWorkforce)
        {
            availableWorkforceDisplayer.DisplayNumber(availableWorkforce);
        }

        private void DisplayInvolvedWorkforce(int involvedWorkforce)
        {
            involvedWorkforceDisplayer.DisplayNumber(involvedWorkforce);
        }
    }
}