using CustomInfoSystem;

namespace ProgressionSystem.Quest
{
    public interface IReward
    {
        void Reward();

        ICustomInfo Info { get; }
    }
}