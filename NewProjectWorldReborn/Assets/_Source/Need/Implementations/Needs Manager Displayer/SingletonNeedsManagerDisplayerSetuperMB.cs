namespace NeedSystem.Implementations
{
    public class SingletonNeedsManagerDisplayerSetuperMB : ANeedsManagerDisplayerSetuperMB
    {
        protected override INeedsManager NeedsManager => NeedsManagerSingleton.Instance;
    }
}