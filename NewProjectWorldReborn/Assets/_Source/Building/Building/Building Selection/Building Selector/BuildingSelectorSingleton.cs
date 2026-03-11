namespace BuildingSystem
{
    public static class BuildingSelectorSingleton
    {
        private static IBuildingSelector _instance;
        public static IBuildingSelector Instance => _instance ??= new BuildingSelector();
    }
}