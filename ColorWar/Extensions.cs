namespace ColorWar;

/// <summary>
/// Расширения.
/// </summary>
internal static class Extensions
{
    /// <summary>
    /// Проверить ячейку.
    /// </summary>
    /// <param name="model">Ячейка.</param>
    /// <param name="color">Цвет.</param>
    /// <param name="forBlack">Флаг уничтожения.</param>
    /// <returns>True - подходит.</returns>
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
