using ProduceInventory.MeProduce.Interfaces;

namespace ProduceInventory.MeProduce
{
    internal class Produce : IProduce
    {
        public uint Id { get; set; }
        public string? NameId { get; set; }
        public string? ProduceType { get; set; }
        public uint Quantity { get; set; }
        public decimal PriceId { get; set; }
        public decimal PriceTotal { get; set; }

        public void SetPriceTotal()
        {
            PriceTotal = PriceId * Quantity;
        }

        public string GetString()
        {
            return $"{Id}|{NameId}|{ProduceType}|{Quantity}|{PriceId}|{PriceTotal}";
        }

        public void ParseString(string stringProduct)
        {
            var prod = stringProduct.Split('|');
            Id = uint.Parse(prod[0]);
            NameId = prod[1];
            ProduceType = prod[2];
            Quantity = uint.Parse(prod[3]);
            PriceId = decimal.Parse(prod[4]);
            PriceTotal = decimal.Parse(prod[5]);
        }
    }
}