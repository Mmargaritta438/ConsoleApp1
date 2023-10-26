using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View.Command
{
    internal class UninstallProduce : IExecutor
    {
        public readonly Startup _manager;
        public string Description { get; }
        private readonly uint _storageIndex;

        public UninstallProduce(Startup manager, uint storageIndex)
        {
            _manager = manager;
            _storageIndex = storageIndex;
            Description = "Uninstll the goods from the storege";
        }

        public void Execute()
        {
            var sroage = _manager.FindStorage(_storageIndex);
            while (true)
            {
                Console.Write("Enter the ID of the produce you want to delete => ");
                if (uint.TryParse(Console.ReadLine(), out var id) && sroage.FindProduce(id) != null)
                {
                    Console.Write("Enter the quantity you want to delete => ");
                    if (uint.TryParse(Console.ReadLine(), out var count))
                    {
                        try
                        {
                            sroage.RemoveTheGoodsFromTheStorage(sroage.FindProduce(id).Id, count);
                            return;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You cannot remove more goods than there actually are.");
                        }
                        Console.WriteLine("Incorrect data entry");
                    }
                    Console.WriteLine("Incorrect data entry");
                }
            }

        }
    }
}