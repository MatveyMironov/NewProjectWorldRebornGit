using ConsumptionSystem;

namespace NeedSystem.Implementations
{
    public class ResourceNeedsManagerSingleton
    {
        private static IResourceNeedsManager _instance;
        public static IResourceNeedsManager Instance
        {
            get
            {
                return _instance ??= new ResourceNeedsManager(ConsumptionsManagerSingleton.Instance);
            }
        }
    }
}