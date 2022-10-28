﻿namespace RCommon.DataServices
{
    public interface IDataStoreRegistry
    {
        TDataStore GetDataStore<TDataStore>(string dataStoreName) where TDataStore : IDataStore;
        void RegisterDataStore<TDataStore>(TDataStore dataStore, string dataStoreName) where TDataStore : IDataStore;
        void RemoveRegisteredDataStore(string dataStoreName);
    }
}