using System.Collections.Generic;

public abstract class StockItem : IReportable
{
    private List<StockMovement> history;
    private int nextSeq;

    public string Sku { get; }
    public string Name { get; }
    public decimal UnitPrice { get; }
    public int QuantityOnHand { get; private set; }

    public int MoveCount
    {
        get { return history.Count; }
    }

    protected StockItem(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand)
    {
        Sku = sku;
        Name = name;
        UnitPrice = unitPrice < 0 ? 0 : unitPrice;
        QuantityOnHand = quantityOnHand < 0
            ? 0
            : quantityOnHand;

        history = new List<StockMovement>();
        nextSeq = 1;
    }

    public abstract string Category();

    public abstract decimal HandlingFee();

    public decimal ExtendedValue()
    {
        return (UnitPrice + HandlingFee())
            * QuantityOnHand;
    }

    public bool Receive(int count)
    {
        if (count <= 0)
            return false;

        QuantityOnHand += count;

        history.Add(
            new StockMovement(
                nextSeq++,
                "Received",
                count));

        return true;
    }

    public bool Release(int count)
    {
        if (count <= 0 ||
            count > QuantityOnHand)
            return false;

        QuantityOnHand -= count;

        history.Add(
            new StockMovement(
                nextSeq++,
                "Released",
                count));

        return true;
    }

    public string MovementLines()
    {
        string result = "";

        foreach (StockMovement move in history)
        {
            result += move.Describe() + "\n";
        }

        return result.TrimEnd();
    }

    public virtual string Describe()
    {
        return $"{Sku} {Name} ({Category()})";
    }

    public string ReportLine()
    {
        return $"{Sku} {Name} ${ExtendedValue():N2}";
    }

    public override string ToString()
    {
        return Describe();
    }
}