namespace SwitchSystem
{
    public interface ISwitch
    {
        int StatesCount { get; }
        int CurrentStateIndex { get; }

        void Switch();
        void SwitchTo(int stateIndex);
        bool TrySwitchTo(int stateIndex);
    }
}