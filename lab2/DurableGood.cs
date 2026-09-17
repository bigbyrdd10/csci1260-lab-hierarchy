public class DurableGood : PhysicalGood
{
    public int WarrantyMonths { get; }

    public DurableGood(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double weightPounds,
        int warrantyMonths)
        : base(
            sku,
            name,
            unitPrice,
            quantityOnHand,
            weightPounds)
    {
        WarrantyMonths = warrantyMonths;
    }

    public override string Category()
    {
        return "Durable";
    }

    public override decimal HandlingFee()
    {
        return ShippingCost();
    }

    public override string Describe()
    {
        return base.Describe() +
               $", {WarrantyMonths} month warranty";
    }
}