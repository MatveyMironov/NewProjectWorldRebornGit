namespace StorageSystem.Testing
{
    internal class SingletonTestResourcesMB : ATestResourcesMB
    {
        private IStorage _storage;
        protected override IStorage Storage => _storage;

        private void Awake()
        {
            _storage = StorageSingleton.Instance;
        }
    }
}