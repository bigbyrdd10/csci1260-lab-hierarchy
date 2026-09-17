public class StockMovement
{
    public int Sequence { get; }

    public string Action { get; }

    public int Count { get; }

    public StockMovement(
        int sequence,
        string action,
        int count)
    {
        Sequence = sequence;
        Action = action;
        Count = count;
    }

    public string Describe()
    {
        return string.Format(
            "move {0}: {1} {2}",
            Sequence,
            Action,
            Count);
    }
}