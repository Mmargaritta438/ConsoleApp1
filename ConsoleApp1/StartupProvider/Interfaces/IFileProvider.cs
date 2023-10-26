using ProduceInventory.Storage.Interfaces;

namespace ProduceInventory.StorageFileProvider.Interfaces
{
    internal interface IFileProvider
    {
        string DefoultPath { get; }
        void Createfile(string name);
        void DeleteFile(string name);

        //void Write(string path, string data);
        //void Read(string path);

        void LoadData(Startup manager);
        void Synchronization(IStorage<uint> storage);
    }
}