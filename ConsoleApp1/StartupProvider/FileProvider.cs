using ProduceInventory.Storage;
using ProduceInventory.Storage.Interfaces;
using ProduceInventory.StorageFileProvider.Interfaces;
using System.Text;
using ProduceInventory.MeProduce;

namespace ProduceInventory.StorageFileProvider
{
    internal class FileProvider : IFileProvider
    {
        public string DefoultPath { get; }


        public FileProvider(string defoultPath)
        {
            DefoultPath = defoultPath;
        }


        public void Createfile(string name)
        {
            if (!File.Exists($"{DefoultPath}\\{name}.txt"))
            {
                FileStream fs = File.Create($"{DefoultPath}\\{name}.txt");
                fs.Close();
            }
            else
            {
                throw new Exception("there is already such a file");
            }
        }


        public void DeleteFile(string name)
        {
            if (File.Exists($"{DefoultPath}\\{name}.txt"))
            {
                File.Delete($"{DefoultPath}\\{name}.txt");
            }
            else
            {
                throw new Exception($"there is no such file");
            }
        }
        public void Synchronization(IStorage<uint> storage)
        {
            if (File.Exists($"{DefoultPath}\\{storage.StorageIndex}.txt"))
            {
                using (StreamWriter writeStream = new StreamWriter($"{DefoultPath}\\{storage.StorageIndex}.txt", false, Encoding.UTF8))
                {
                    foreach (var produce in storage.AllProduces)
                    {
                        writeStream.WriteLine(produce.GetString());
                    }
                }
            }
            else
            {
                throw new Exception($"there is no such file {DefoultPath}\\{storage.StorageIndex}.txt");
            }
        }


        public void LoadData(Startup manager)
        {
            if (Directory.Exists($"{DefoultPath}\\"))
            {

                var files = Directory.GetFiles(DefoultPath).ToList();
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var storageIndex = uint.Parse(fileName.Remove(fileName.Length - 4));
                    Startup<uint> storage = new Startup<uint>(storageIndex);

                    foreach (var lineProduce in File.ReadAllLines($"{DefoultPath}\\{storageIndex}.txt"))
                    {
                        Produce produce = new Produce();
                        produce.ParseString(lineProduce);
                        storage.ProduceAddToTheStorage(produce);
                    }

                    manager.LoadStorage(storage);
                }
            }
        }
    }
}