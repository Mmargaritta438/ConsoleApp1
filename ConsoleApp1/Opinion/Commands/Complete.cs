using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View.Command
{
    internal class ChangeComplete : IExecutor
    {
        public string Description { get; }

        public ChangeComplete()
        {
            Description = "Select storage.";
        }

        public void Execute()
        {

        }
    }
}