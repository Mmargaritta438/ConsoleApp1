using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View
{
    internal class ProducteAdd : IExecutor
    {
        private Startup storageManager;
        private uint storageIndex;

        public ProducteAdd(Startup storageManager, uint storageIndex)
        {
            this.storageManager = storageManager;
            this.storageIndex = storageIndex;
        }

        public string Description => throw new NotImplementedException();

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}