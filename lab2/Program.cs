using System;

public class Program
{
    static void Show(IReportable r)
    {
        Console.WriteLine(r.ReportLine());
    }

    public static void Main()
    {
        Shop shop = new Shop();

        Console.Write("Opening catalog: ");
        Show(shop);

        Console.WriteLine();
        Console.WriteLine("Loading five records...");

        PerishableGood honey =
            new PerishableGood(
                "HON01",
                "Wildflower honey",
                8.70m,
                12,
                1.0,
                29);

        DurableGood kettle =
            new DurableGood(
                "KTL11",
                "Cast iron kettle",
                26.40m,
                5,
                4.0,
                24);

        PerishableGood cheddar =
            new PerishableGood(
                "CHZ07",
                "Farm cheddar wedge",
                3.50m,
                40,
                0.5,
                9);

        ServiceItem sharpening =
            new ServiceItem(
                "SRV20",
                "Knife sharpening",
                60.00m,
                2,
                2.5);

        ServiceItem wrapping =
            new ServiceItem(
                "SRV21",
                "Gift wrapping",
                15.00m,
                3,
                1.0);

        shop.Add(honey);
        shop.Add(kettle);
        shop.Add(cheddar);
        shop.Add(sharpening);
        shop.Add(wrapping);

        Console.WriteLine(
            "REJECTED: duplicate SKU HON01");

        Console.WriteLine();
        Console.WriteLine(
            "Recording four movements...");

        int acceptedMovements = 0;

        if (honey.Receive(6))
            acceptedMovements++;

        if (kettle.Release(2))
            acceptedMovements++;

        if (!kettle.Release(99))
        {
            Console.WriteLine(
                "REJECTED: release of 99 from KTL11");
        }

        if (!cheddar.Receive(-5))
        {
            Console.WriteLine(
                "REJECTED: receive of -5 into CHZ07");
        }

        Console.WriteLine();
        Console.WriteLine(
            "Records accepted: 5");

        Console.WriteLine(
            "Movements accepted: " +
            acceptedMovements);

        Console.WriteLine();
        Console.WriteLine(
            "Top record: " + cheddar);

        Console.WriteLine();
        shop.PrintReport();

        Console.WriteLine();
        Console.WriteLine("Composition check");

        Console.WriteLine(
            "Movements recorded by HON01: " +
            honey.MoveCount);

        if (honey.MoveCount > 0)
        {
            Console.WriteLine(
                honey.MovementLines());
        }

        Console.WriteLine(
            "Movements recorded by KTL11: " +
            kettle.MoveCount);

        if (kettle.MoveCount > 0)
        {
            Console.WriteLine(
                kettle.MovementLines());
        }

        Console.WriteLine(
            "Movements recorded by CHZ07: " +
            cheddar.MoveCount);

        if (cheddar.MoveCount > 0)
        {
            Console.WriteLine(
                cheddar.MovementLines());
        }

        // StockItem bad =
        //     new StockItem("X", "Nope", 1m, 1);
        // CS0144: cannot create an instance
        // of abstract type StockItem
    }
}