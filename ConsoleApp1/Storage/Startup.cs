using ProduceInventory.MeProduce.Interfaces;
using ProduceInventory.Storage.Interfaces;

namespace ProduceInventory.Storage
{
    internal class Startup<TStorageIndex> : IStorage<TStorageIndex>
    {


        public TStorageIndex StorageIndex { get; }

        public List<IProduce> AllProduces { get; }

        public Startup(TStorageIndex warehouseIndex)
        {
            StorageIndex = warehouseIndex;
            AllProduces = new List<IProduce>();
        }

        public void ProduceAddToTheStorage(IProduce produce)
        {
            if (FindProduce(produce.Id) == null)
            {
                produce.SetPriceTotal();
                AllProduces.Add(produce);
            }
            else
            {
                FindProduce(produce.Id).Quantity += produce.Quantity;
                FindProduce(produce.Id).SetPriceTotal();
            }
        }

        public void RemoveTheGoodsFromTheStorage(uint produceIndex, uint quantity)
        {
            if (FindProduce(produceIndex) != null)
            {
                var product = FindProduce(produceIndex);
                if (product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    if (product.Quantity == 0)
                        AllProduces.Remove(product);

                }
                else
                    throw new Exception("You can't delete more than you actually have");
            }
            else
            {
                throw new Exception("The specified product does not exist");
            }
        }

        public void ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity)
        {

            FindProduce(productIndex).Quantity = quantity;
            FindProduce(productIndex).SetPriceTotal();
        }

        public Dictionary<string, List<IProduce>> SplitProducesIntoCategories()
        {
            var ProductsCategories = new Dictionary<string, List<IProduce>>();
            foreach (var produce in AllProduces)
            {
                if (ProductsCategories.ContainsKey(produce.ProduceType))
                {
                    ProductsCategories[produce.ProduceType].Add(produce);
                }
                else if (!ProductsCategories.ContainsKey(produce.ProduceType))
                {
                    ProductsCategories.Add(produce.ProduceType, new List<IProduce>());
                    ProductsCategories[produce.ProduceType].Add(produce);
                }
            }
            return ProductsCategories;
        }



        public IProduce FindProduce(uint produceIndex)
        {
            return AllProduces.FirstOrDefault(x => x.Id == produceIndex);
        }
    }
}