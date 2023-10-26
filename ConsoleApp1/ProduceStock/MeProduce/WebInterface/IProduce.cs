namespace ProduceInventory.MeProduce.Interfaces
{
    internal interface IProduce
    {
        uint Id { get; set; }
        string NameId { get; set; }
        string ProduceType { get; set; }
        uint Quantity { get; set; }
        decimal PriceId { get; set; }
        decimal PriceTotal { get; set; }
        public void SetPriceTotal();
        void ParseString(string stringProduce);
        string GetString();
    }
}