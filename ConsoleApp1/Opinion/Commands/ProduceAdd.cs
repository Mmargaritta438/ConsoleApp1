using ProduceInventory;
using ProduceInventory.View.Interfaces;
namespace ProduceStock.View.Command
{
    internal class ProduceAdd : IExecutor
    {
        public readonly Startup _manager;
        public string Description { get; }
        private readonly uint _storageIndex;

        public ProduceAdd(Startup manager, uint storageIndex)
        {
            Description = "Add product to storage";
            _manager = manager;
            _storageIndex = storageIndex;
        }

        public void Execute()
        {
            Console.Clear();

            var produce = new ProduceInventory.MeProduce.Produce();

            while (true)
            {

                Console.Write("Enter unique ID =>");

                if (uint.TryParse(Console.ReadLine(), out var id))
                {
                    produce.Id = id;
                    break;
                }
                else
                
                Console.WriteLine("The value is incorrect, try again");
            }

            Console.Write("Enter produce name =>");
            produce.NameId = Console.ReadLine();

            Console.Write("Enter produce type =>");
            produce.ProduceType = Console.ReadLine();

            while (true)
            {

                Console.Write("Enter quantity =>");

                if (uint.TryParse(Console.ReadLine(), out var quantity))
                {
                    produce.Quantity = quantity;
                    break;
                }
                else
                    
                Console.WriteLine("The value is incorrect, try again");
            }

            while (true)
            {
                
                Console.Write("Enter the original price of the produce =>");

                if (decimal.TryParse(Console.ReadLine(), out var price))
                {
                    produce.PriceId = price;
                    break;
                }
                else
                   
                Console.WriteLine("The value is incorrect, try again");
            }

            produce.SetPriceTotal();
            _manager.AddProduce(_storageIndex, produce);

        }
    }
}