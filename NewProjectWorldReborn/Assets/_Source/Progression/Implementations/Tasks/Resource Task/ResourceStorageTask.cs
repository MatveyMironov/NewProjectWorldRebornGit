using CustomInfoSystem;
using ResourceSystem;
using StorageSystem;
using System;

namespace ProgressionSystem.Implementations
{
    public class ResourceStorageTask : ITask
    {
        private readonly IResourceDefinition _targetResource;
        private readonly int _targetAmount;

        public ResourceStorageTask(IResourceDefinition targetResource, int targetAmount, IStorage storage, ResourceStorageTaskDisplayerMB displayerPrefab)
        {
            _targetResource = targetResource ?? throw new ArgumentNullException(nameof(targetResource));
            _targetAmount = targetAmount;

            Info = new ResourceStorageTaskInfo(this, displayerPrefab);

            if (storage is null) throw new ArgumentNullException(nameof(storage));

            storage.OnResourceCountChanged += CheckResourceCount;

            TryUpdateStoredAmount();

            void CheckResourceCount(IResourceDefinition resource)
            {
                if (resource != _targetResource) return;

                TryUpdateStoredAmount();
            }

            void TryUpdateStoredAmount()
            {
                UpdateStoredAmount(storage.GetResourceCount(targetResource));
            }

            void UpdateStoredAmount(int storedAmount)
            {
                StoredAmount = storedAmount;
                OnStoredAmountChanged?.Invoke(storedAmount);

                if (storedAmount == _targetAmount)
                {
                    CompleteTask();
                }
            }

            void CompleteTask()
            {
                storage.OnResourceCountChanged -= CheckResourceCount;

                IsCompleted = true;
                OnCompleted?.Invoke();
            }
        }

        public IResourceDefinition TargetResource { get => _targetResource; }
        public int TargetAmount { get => _targetAmount; }

        public int StoredAmount { get; private set; }
        public event Action<int> OnStoredAmountChanged;

        public bool IsCompleted { get; private set; }
        public event Action OnCompleted;

        public ICustomInfo Info { get; }
    }
}