using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WorkforceReserveSystem.Testing
{
    public abstract class ATestWorkforceReserveButtonsMB : MonoBehaviour
    {
        [SerializeField] private TMP_InputField amountInputField;
        [SerializeField] private Button addButton;
        [SerializeField] private Button removeButton;

        protected abstract IWorkforceReserve WorkforceReserve { get; }

        protected virtual void Start()
        {
            addButton.onClick.AddListener(AddWorkforce);
            removeButton.onClick.AddListener(RemoveWorkforce);
        }

        private void AddWorkforce()
        {
            WorkforceReserve.IncreaseTotalWorkforce(GetNumberInput());
        }

        private void RemoveWorkforce()
        {
            WorkforceReserve.TryDecreaseTotalWorkforce(GetNumberInput());
        }

        private int GetNumberInput()
        {
            return int.Parse(amountInputField.text);
        }
    }
}