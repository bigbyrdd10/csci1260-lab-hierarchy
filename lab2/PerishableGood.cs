public class PerishableGood :
    PhysicalGood, IDiscountable
{
    public const decimal SurchargeFee = 0.40m;

    public int ShelfLifeDays { get; }

    public PerishableGood(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double weightPounds,
        int shelfLifeDays)
        : base(
            sku,
            name,
            unitPrice,
            quantityOnHand,
            weightPounds)
    {
        ShelfLifeDays = shelfLifeDays;
    }

    public override string Category()
    {
        return "Perishable";
    }

    public override decimal HandlingFee()
    {
        return ShippingCost() + SurchargeFee;
    }

    public bool IsOnSale
    {
        get { return ShelfLifeDays <= 3; }
    }

    public decimal SalePrice()
    {
        if (IsOnSale)
        {
            return UnitPrice * 0.70m;
        }

        return UnitPrice;
    }

    public override string Describe()
    {
        return base.Describe() +
               $", {ShelfLifeDays} days left";
    }
}