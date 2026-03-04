using BuildingSystem;
using CustomInfoSystem;
using ProgressionSystem.Quest;

namespace ProgressionSystem.Implementations
{
    public class BuildingReward : IReward
    {
        private readonly IBuildingConfigurationsManager _buildingConfigurationsManager;

        public BuildingReward(IBuildingConfiguration building, BuildingRewardDisplayerMB displayerPrefab, IBuildingConfigurationsManager buildingConfigurationsManager)
        {
            Building = building ?? throw new System.ArgumentNullException(nameof(building));
            _buildingConfigurationsManager = buildingConfigurationsManager ?? throw new System.ArgumentNullException(nameof(buildingConfigurationsManager));

            Info = new BuildingRewardInfo(this, displayerPrefab);
        }

        public IBuildingConfiguration Building { get; }

        public ICustomInfo Info { get; }

        public void Reward()
        {
            _buildingConfigurationsManager.TryAddConfiguration(Building);
        }
    }
}