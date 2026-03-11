namespace BuildingSystem
{
    public static class BuildingInteractionsManagerSingleton
    {
        private static IBuildingInteractionsManager _instance;
        public static IBuildingInteractionsManager Instance => _instance ??= new BuildingInteractionsManager(BuildingSelectorSingleton.Instance);
    }
}