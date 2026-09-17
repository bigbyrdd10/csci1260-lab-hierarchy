public class ServiceItem :
    StockItem, IDiscountable
{
    public double LaborHours { get; }

    public ServiceItem(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double laborHours)
        : base(
            sku,
            name,
            unitPrice,
            quantityOnHand)
    {
        LaborHours = laborHours;
    }

    public override string Category()
    {
        return "Service";
    }

    public override decimal HandlingFee()
    {
        return 0;
    }

    public bool IsOnSale
    {
        get { return LaborHours > 5; }
    }

    public decimal SalePrice()
    {
        if (IsOnSale)
        {
            return UnitPrice * 0.80m;
        }

        return UnitPrice;
    }

    public override string Describe()
    {
        return base.Describe() +
               $", {LaborHours} labor hours";
    }
}