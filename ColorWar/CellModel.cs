namespace ColorWar;

internal class CellModel
{
    public ColorCell Color { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Who Who { get; set; }

    public CellModel Top { get; set; }
    public CellModel Right { get; set; }
    public CellModel Bottom { get; set; }
    public CellModel Left { get; set; }
}

public enum Who
{
    Neutral,
    First,
    Second,
    Computer
}