namespace ColorWar;

internal static class Extensions
{
    internal static bool CheckCell(this CellModel model, ColorCell color, bool forBlack = false)
        => forBlack
            ? model is not null && model.Color == color
            : model is not null
                && (model.Color == color
                    || model.Color == ColorCell.neutral
                    || model.Color == ColorCell.cross
                    || model.Color == ColorCell.flag
                    || model.Color == ColorCell.multi)
                && model.Who == Who.Neutral;
}
