using System;

namespace BuildingSystem
{
    public interface IBuildingConfigurationsManager
    {
        IBuildingConfiguration[] BuildingConfigurations { get; }
        event Action<IBuildingConfiguration> OnBuildingConfigurationAdded;
        event Action<IBuildingConfiguration> OnBuildingConfigurationRemoved;

        bool TryAddConfiguration(IBuildingConfiguration configuration);
        bool TryRemoveConfiguration(IBuildingConfiguration configuration);
    }
}