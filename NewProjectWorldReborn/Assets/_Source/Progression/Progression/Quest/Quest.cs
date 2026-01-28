using System;

namespace ProgressionSystem.Quest
{
    public class Quest
    {
        public ITask Task { get; }
        public IReward Reward { get; }

        public Quest(ITask task, IReward reward)
        {
            Task = task ?? throw new ArgumentNullException(nameof(task));
            Reward = reward ?? throw new ArgumentNullException(nameof(reward));

            if (Task.IsCompleted)
            {
                Finish();
            }
        }

        public bool IsStarted { get; private set; }
        public bool IsFinished { get; private set; }
        public event Action OnFinished;

        public void Start()
        {
            if (IsStarted) return;
            if (IsFinished) return;

            Task.OnCompleted += Finish;
            IsStarted = true;
        }

        public void Cancel()
        {
            if (!IsStarted) return;

            Task.OnCompleted -= Finish;
            IsStarted = false;
        }

        private void Finish()
        {
            if (IsFinished) return;

            Reward.Reward();
            Cancel();
            IsFinished = true;
            OnFinished?.Invoke();
        }
    }
}