using CustomInfoSystem;

namespace ProgressionSystem
{
    public interface IReward
    {
        void Reward();

        ICustomInfo Info { get; }
    }
}