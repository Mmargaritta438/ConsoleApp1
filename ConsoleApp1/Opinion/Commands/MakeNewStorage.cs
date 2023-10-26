using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View.Command
{
    internal class MakeNewStorage : IExecutor
    {
        public readonly Startup _manager;

        public MakeNewStorage(Startup manager)
        {
            _manager = manager;
            Description = "Make a new storage.";
        }

        public string Description { get; }

        public void Execute()
        {
            Console.Clear();
            do
            {
                Console.Write("\r\nEnter new storage numbe => ");
                if (uint.TryParse(Console.ReadLine(), out uint StorageID))
                {
                    try
                    {
                        _manager.MakeNewWarehouse(StorageID);
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Such a storage already exists");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            } while (true);
        }
    }
}