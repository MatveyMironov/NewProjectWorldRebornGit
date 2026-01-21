namespace NeedSystem.Testing
{
    public class SingletonTestNeedsMB : ATestNeedsMB
    {
        protected override INeedsManager NeedsManager => NeedsManagerSingleton.Instance;
    }
}