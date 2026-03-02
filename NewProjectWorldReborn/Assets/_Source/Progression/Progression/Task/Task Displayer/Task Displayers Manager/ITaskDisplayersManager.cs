namespace ProgressionSystem
{
    public interface ITaskDisplayersManager
    {
        bool TryAddTaskDisplayer(ITask task);
        bool TryRemoveTaskDisplayer(ITask task);
    }
}