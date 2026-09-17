using System;
using System.Collections.Generic;

public class Shop : IReportable
{
    private List<StockItem> items;

    public int Count
    {
        get { return items.Count; }
    }

    public Shop()
    {
        items = new List<StockItem>();
    }

    public bool Add(StockItem item)
    {
        foreach (StockItem existing in items)
        {
            if (existing.Sku == item.Sku)
                return false;
        }

        items.Add(item);
        return true;
    }

    public decimal TotalValue()
    {
        decimal total = 0;

        foreach (StockItem item in items)
        {
            total += item.ExtendedValue();
        }

        return total;
    }

    public string ReportLine()
    {
        return $"River City Supply: {Count} items, ${TotalValue():N2} on hand";
    }

    public void PrintReport()
    {
        Console.WriteLine(
            "============================================================");

    Console.WriteLine(
        "RIVER CITY SUPPLY : INVENTORY REPORT");

    Console.WriteLine(
        "============================================================");

    Console.WriteLine(
        string.Format(
            " {0,-7} {1,-21} {2,-10} {3,4} {4,11}",
            "SKU",
            "ITEM",
            "CATEGORY",
            "QTY",
            "VALUE"));

    Console.WriteLine(
        "------------------------------------------------------------");

    foreach (StockItem item in items)
    {
        Console.WriteLine(item.ReportLine());
    }

    Console.WriteLine(
        "------------------------------------------------------------");

    Console.WriteLine(
        string.Format(
            " {0,-46} {1,11}",
            "Records on file:",
            Count));

    Console.WriteLine(
        string.Format(
            " {0,-46}${1,11:N2}",
            "Total value on hand:",
            TotalValue()));

    Console.WriteLine(
        "============================================================");
    }
}
