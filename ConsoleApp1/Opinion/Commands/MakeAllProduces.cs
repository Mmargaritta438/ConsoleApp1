using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View.Command
{
    internal class MakeAllProduces : IExecutor
    {
        public readonly Startup _manager;
        public string Description { get; }
        private readonly uint _storageIndex;

        public MakeAllProduces(Startup storage, uint storageIndex)
        {
            _manager = storage;
            _storageIndex = storageIndex;
            Description = "Make all produces";
        }

        public void Execute()
        {
            Console.Clear();
            var storage = _manager.FindStorage(_storageIndex);
            Console.WriteLine("+----------------+---------------------------------+----------------------+------------+--------------+-----------------+");
            Console.WriteLine("|:):):):):):):)::):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):)|");
            Console.WriteLine("|:)                                                                                                                   :)|");
            Console.WriteLine("|:) Unique code |             Name            |     type of produce     | Quantity | amount per piece | total amount  :)|");
            Console.WriteLine("|:)                                                                                                                   :)|");
            Console.WriteLine("|:):):):):):):):)::):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):):)|");
            Console.WriteLine("+----------------+---------------------------------+----------------------+------------+--------------+-----------------+");

            for (int i = 0; i < storage.AllProduces.Count; i++)
            {
                Console.Write($"| {storage.AllProduces[i].Id}");
                Console.SetCursorPosition(17, i + 3);
                Console.Write($"| {storage.AllProduces[i].NameId}");
                Console.SetCursorPosition(51, i + 3);
                Console.Write($"| {storage.AllProduces[i].ProduceType}");
                Console.SetCursorPosition(74, i + 3);
                Console.Write($"| {storage.AllProduces[i].Quantity}");
                Console.SetCursorPosition(87, i + 3);
                Console.Write($"| {storage.AllProduces[i].PriceId}");
                Console.SetCursorPosition(102, i + 3);
                Console.Write($"| {storage.AllProduces[i].PriceTotal}");
                Console.SetCursorPosition(116, i + 3);
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("+----------------+---------------------------------+----------------------+------------+--------------+-------------+");
        }
    }
}