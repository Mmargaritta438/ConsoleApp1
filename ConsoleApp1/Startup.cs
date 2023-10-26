using ProduceInventory.MeProduce.Interfaces;
using ProduceInventory.Storage;
using ProduceInventory.Storage.Interfaces;
using ProduceInventory.StorageFileProvider;

namespace ProduceInventory
{
    internal record Startup(List<IStorage<uint>> Storage)
    {
        private FileProvider _fileProvider { get; set; }


        public Startup(string V) : this(new List<IStorage<uint>>())
        {
        }

        public Startup(List<IStorage<uint>> storage, FileProvider fileProvider) : this(storage)
        {
            _fileProvider = fileProvider;
        }

        //public Startup(string DefoultPath) : this(default)
        //{
        //    _fileProvider = new FileProvider(DefoultPath);
        //   _fileProvider.LoadData(this);
        //}

        public void LoadStorage(Startup<uint> storage)
        {
            if (FindStorage(storage.StorageIndex) == null)
            {
                Storage.Add(storage);
            }
            else
            {
                throw new Exception("such a storage already exists");
            }
        }

        public void MakeNewWarehouse(uint storageIndex)
        {
            if (FindStorage(storageIndex) == null)
            {
                Storage.Add(new Startup<uint>(storageIndex));
                _fileProvider.Createfile($"{storageIndex}");
            }
            else
            {
                throw new Exception("such a storage already exists");
            }
        }


        public void DeleteStorage(uint storageIndex)
        {
            if (FindStorage(storageIndex) != null)
            {
                Storage.Remove(FindStorage(storageIndex));
                _fileProvider.DeleteFile($"{_fileProvider.DefoultPath}\\{storageIndex}");
            }
            else
            {
                throw new Exception("There is no such storage");
            }
        }


        public List<IProduce> GetListAllProducts(uint storageIndex)
        {
            if (FindStorage(storageIndex) != null)
            {
                return FindStorage(storageIndex).AllProduces;
            }
            else
            {
                throw new Exception("Attempt to access a non-existent storage");
            }
        }


        public void AddProduce(uint warehouseIndex, IProduce product)
        {
            if (FindStorage(warehouseIndex) != null)
            {
                var warehouse = FindStorage(warehouseIndex);
                warehouse.ProduceAddToTheStorage(product);
                _fileProvider.Synchronization(warehouse);
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public void RemoveProduct(uint warehouseIndex, uint productIndex, uint quantity)
        {
            if (FindStorage(warehouseIndex) != null)
            {
                FindStorage(warehouseIndex).RemoveTheGoodsFromTheStorage(productIndex, quantity);
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public Dictionary<string, List<IProduce>> GetProductCategories(uint warehouseIndex)
        {
            if (FindStorage(warehouseIndex) != null)
            {
                return FindStorage(warehouseIndex).SplitProducesIntoCategories();
            }
            else
            {
                throw new Exception("Нет такого склада");
            }
        }

        public void MovingTheProduct(uint warehouseFromWhere, uint warehouseWhere, uint productIndex, uint quantity)
        {
            var _warehouseFromWhere = FindStorage(warehouseFromWhere);
            var _warehouseWhere = FindStorage(warehouseWhere);

            if (_warehouseFromWhere != null && _warehouseWhere != null)
            {
                _warehouseFromWhere.RemoveTheGoodsFromTheStorage(productIndex, quantity);
                _warehouseWhere.ProduceAddToTheStorage(_warehouseFromWhere.FindProduce(productIndex));
            }
            else
            {
                throw new Exception("Нет такого склада");
            }
        }

        public IStorage<uint> FindStorage(uint warehouseIndex)
        {
            return Storage.Find(x => x.StorageIndex == warehouseIndex);
        }

        internal void DeleteWarehouse(object storageID)
        {
            throw new NotImplementedException();
        }
    }
}