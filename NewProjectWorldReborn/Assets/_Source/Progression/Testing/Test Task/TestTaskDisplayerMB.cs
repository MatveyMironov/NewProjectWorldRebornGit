using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProgressionSystem.Testing
{
    public class TestTaskDisplayerMB : MonoBehaviour
    {
        [SerializeField] private Button completeButton;
        [SerializeField] private TextMeshProUGUI nameText;

        public void DisplayTask(TestTask task)
        {
            completeButton.onClick.AddListener(task.Compete);
            nameText.text = task.Name;
        }
    }
}