using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View.Command
{
    internal class DeleteStartup : IExecutor
    {
        public readonly Startup _manager;
        public string Description { get; }

        public DeleteStartup(Startup manager)
        {
            _manager = manager;
            Description = "Delete storage";
        }

        public void Execute()
        {
            Console.Clear();
            LookAllStorage show = new LookAllStorage(_manager);
            show.Execute();
            do
            {
                Console.Write("Enter the storage number you want to delete => ");
                if (uint.TryParse(Console.ReadLine(), out uint StorageID))
                {
                    try
                    {
                        _manager.DeleteStorage(StorageID);
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("This storage does not exist");
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