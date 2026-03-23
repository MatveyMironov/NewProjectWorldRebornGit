using CustomInfoSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class TaskDisplayerMB : ATaskDisplayerMB
    {
        [SerializeField] private CustomInfoDisplayerMB infoDisplayer;
        [SerializeField] private GameObject checkmarkImage;

        private ITask _displayedTask;

        private void Awake()
        {
            DisplayTaskNotCompleted();
        }

        public override void DisplayTask(ITask task)
        {
            Clear();

            DisplayInfo();
            DisplayCompletion();

            _displayedTask = task;

            void DisplayInfo()
            {
                infoDisplayer.DisplayInfo(task.Info);
            }

            void DisplayCompletion()
            {
                task.OnCompleted += DisplayTaskCompleted;

                if (task.IsCompleted)
                {
                    DisplayTaskCompleted();
                }
                else
                {
                    DisplayTaskNotCompleted();
                }
            }
        }

        public override void Clear()
        {
            if (_displayedTask == null) return;

            ClearInfo();
            ClearCompletion();

            _displayedTask = null;

            void ClearInfo()
            {
                infoDisplayer.Clear();
            }

            void ClearCompletion()
            {
                _displayedTask.OnCompleted -= DisplayTaskCompleted;
                DisplayTaskNotCompleted();
            }
        }

        private void DisplayTaskNotCompleted()
        {
            checkmarkImage.SetActive(false);
        }

        private void DisplayTaskCompleted()
        {
            checkmarkImage.SetActive(true);
        }
    }
}