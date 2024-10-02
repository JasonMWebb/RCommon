namespace RCommon.Persistence
{
    public interface IDataStoreFactory
    {
        TDataStore Resolve<TDataStore>(string name)
            where TDataStore : IDataStore;
    }
}
