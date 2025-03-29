using System.Collections.Generic;

namespace ColorWar;

internal class Player(Who who, bool isFirst)
{
    public Who Who { get; set; } = who;
    public ColorCell CurrentColor { get; set; } = ColorCell.neutral;
    public bool IsActive { get; set; } = isFirst;
    public int Score { get; set; } = 0;

    public Dictionary<ColorCell, int> CellCounts = new()
    {
        [ColorCell.blue] = 0,
        [ColorCell.green] = 0,
        [ColorCell.cyan] = 0,
        [ColorCell.red] = 0,
        [ColorCell.fuchsia] = 0,
    };

    public int CellCount { get; set; } = 0;
    public float Percent { get; set; } = 0;
}
