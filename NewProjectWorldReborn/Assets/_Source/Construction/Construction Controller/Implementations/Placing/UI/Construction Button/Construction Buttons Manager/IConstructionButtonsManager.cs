using PlacingSystem;

namespace ConstructionUISystem
{
    public interface IConstructionButtonsManager
    {
        public bool TryAddConstructionButton(IConstructionConfiguration construction);
        public bool TryRemoveConstructionButton(IConstructionConfiguration construction);
    }
}