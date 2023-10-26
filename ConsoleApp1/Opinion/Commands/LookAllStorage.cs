using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View.Command
{
    internal class LookAllStorage : IExecutor
    {
        public readonly Startup _manager;

        public LookAllStorage(Startup manager)
        {
            Description = "\r\nShow a list of all storage.";
            _manager = manager;
        }

        public string Description { get; }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("|:):):):):):):):):):):)|");
            Console.WriteLine("|:)                  :)|");
            Console.WriteLine("|:) Storage numbers  :)|");
            Console.WriteLine("|:)                  :)|");
            Console.WriteLine("|:):):):):):):):):):):)|");
            Console.WriteLine("+----------------+");

            for (int i = 0; i < _manager.Storage.Count; i++)
            {
                Console.Write($"| {_manager.Storage[i].StorageIndex}");
                Console.SetCursorPosition(17, i + 3);
                Console.Write("|\n");
            }
            Console.WriteLine("+----------------+");
        }
    }
}