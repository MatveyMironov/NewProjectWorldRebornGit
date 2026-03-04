namespace BuildingSystem
{
    public static class StructureBuildingsManagerSingleton
    {
        private static IStructureBuildingsManager _instance;
        public static IStructureBuildingsManager Instance => _instance ??= new StructureBuildingsManager(BuildingSelectionActionsManagerSingleton.Instance);
    }
}