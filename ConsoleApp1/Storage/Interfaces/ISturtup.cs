using ProduceInventory.MeProduce.Interfaces;

namespace ProduceInventory.Storage.Interfaces
{
    internal interface IStorage<TStorageIndex>
    {
        public TStorageIndex StorageIndex { get; }
        public List<IProduce> AllProduces { get; }

        //add a certain amount of produce
        public void ProduceAddToTheStorage(IProduce produce);

        //remove a certain amount of produce
        public void RemoveTheGoodsFromTheStorage(uint produceIndex, uint quantity);

        //change produce quantity
        public void ChangeTheQuantityOfGoodsInStock(uint produceIndex, uint quantity);

        //break produces into categories
        public Dictionary<string, List<IProduce>> SplitProducesIntoCategories();

        public IProduce FindProduce(uint produceIndex);
    }
}