public abstract class PhysicalGood : StockItem
{
    public const decimal HandlingRate = 0.60m;

    public double WeightPounds { get; }

    protected PhysicalGood(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double weightPounds)
        : base(
            sku,
            name,
            unitPrice,
            quantityOnHand)
    {
        WeightPounds =
            weightPounds < 0
            ? 0
            : weightPounds;
    }

    public decimal ShippingCost()
    {
        return (decimal)WeightPounds
               * HandlingRate;
    }

    public override string Describe()
    {
        return base.Describe() +
               $", {WeightPounds:N1} lb";
    }
}