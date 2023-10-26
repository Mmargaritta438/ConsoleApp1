namespace ProduceInventory.View.Interfaces
{
    internal interface IExecutor
    {
        public string Description { get; }
        public void Execute();
    }
}