namespace StorageSystem.Implementations
{
    public class SingletonStorageDisplayerSetuperMB : AStorageDisplayerSetuperMB
    {
        protected override IStorage Storage => StorageSingleton.Instance;
    }
}