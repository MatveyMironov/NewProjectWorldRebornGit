namespace ProgressionSystem
{
    public interface ITaskDisplayer
    {
        void DisplayTask(ITask task);
        void Clear();
    }
}