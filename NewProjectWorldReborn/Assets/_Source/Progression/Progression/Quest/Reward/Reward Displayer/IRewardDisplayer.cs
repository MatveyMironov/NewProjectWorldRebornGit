namespace ProgressionSystem.Quest
{
    public interface IRewardDisplayer
    {
        void DisplayReward(IReward reward);
        void Clear();
    }
}