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

    public void ChangeCell(Who player, ColorCell color)
    {
        Color = ConvertColor(color);
        Who = player;

        if (Top.CheckCell(color))
        {
            Top.ChangeCell(player, color);
        }

        if (Right.CheckCell(color))
        {
            Right.ChangeCell(player, color);
        }

        if (Bottom.CheckCell(color))
        {
            Bottom.ChangeCell(player, color);
        }

        if (Left.CheckCell(color))
        {
            Left.ChangeCell(player, color);
        }
    }

    public static ColorCell ConvertColor(ColorCell colorCell)
        => colorCell switch
        {
            ColorCell.blue => ColorCell.blueset,
            ColorCell.green => ColorCell.greenset,
            ColorCell.cyan => ColorCell.cyanset,
            ColorCell.red => ColorCell.redset,
            ColorCell.fuchsia => ColorCell.fuchsiaset,
            _ => ColorCell.neutral
        };
}

public enum Who
{
    Neutral,
    First,
    Second,
    Computer
}