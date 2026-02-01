namespace BuildingSystem
{
    public static class BuildingSelectionActionsManagerSingleton
    {
        private static IBuildingSelectionActionsManager _instance;
        public static IBuildingSelectionActionsManager Instance => _instance ??= new BuildingSelectionActionsManager(BuildingSelectorSingleton.Instance);
    }
}