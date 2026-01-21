namespace NeedSystem
{
    public static class NeedsManagerSingleton
    {
        private static INeedsManager _instance;
        public static INeedsManager Instance
        {
            get
            {
                return _instance ??= new NeedsManager();
            }
        }
    }
}