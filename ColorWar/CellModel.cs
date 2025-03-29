using System.Windows.Forms;

namespace ColorWar;

/// <summary>
/// Модель ячейки.
/// </summary>
/// <param name="game">Текущая игра.</param>
internal class CellModel(Game game)
{
    #region Основные параметры

    /// <summary>
    /// Цвет.
    /// </summary>
    public ColorCell Color { get; set; }

    /// <summary>
    /// Индекс по ширине поля.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Индекс по высоте поля.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Принадлежность.
    /// </summary>
    public Who Who { get; set; }

    #endregion

    #region Соседние ячейки

    /// <summary>
    /// Верхняя соседняя ячейка.
    /// </summary>
    public CellModel Top { get; set; }

    /// <summary>
    /// Правая соседняя ячейка.
    /// </summary>
    public CellModel Right { get; set; }

    /// <summary>
    /// Нижняя соседняя ячейка.
    /// </summary>
    public CellModel Bottom { get; set; }

    /// <summary>
    /// Левая соседняя ячейка.
    /// </summary>
    public CellModel Left { get; set; }

    #endregion

    private Game CurrentGame { get; } = game;

    /// <summary>
    /// Изменить ячейку.
    /// </summary>
    /// <param name="player">Игрок.</param>
    /// <param name="color">Цвет.</param>
    /// <param name="forBlack">Флаг уничтожения.</param>
    public void ChangeCell(Who player, ColorCell color, bool forBlack = false)
    {
        if (forBlack)
        {
            Color = ColorCell.black;
        }
        else
        {
            if (Color == ColorCell.flag)
            {
                AddScore(Color);
                ++CurrentGame.ActivePlayer.CellCount;
                CurrentGame.SetPercentPlayer();
            }
            else if (Color == ColorCell.multi)
            {
                ++CurrentGame.ActivePlayer.CellCount;
                CurrentGame.SetPercentPlayer();
                FieldModel.ChangeColorCollection.Enqueue(LocalRandom.GetColorWithout(CurrentGame.GetColor()));
            }

            if (Color == ColorCell.cross)
            {
                Color = ColorCell.black;
                color = LocalRandom.GetColor();
                forBlack = true;
                MessageBox.Show($"БА-БАХ! Уничтожены клетки: {color}");
            }
            else
            {
                AddScore(color);
                Color = ConvertColor(color);
                Who = player;
                ++CurrentGame.ActivePlayer.CellCount;
                CurrentGame.SetPercentPlayer();
            }
        }

        if (Top.CheckCell(color, forBlack))
        {
            Top.ChangeCell(player, color, forBlack);
        }

        if (Right.CheckCell(color, forBlack))
        {
            Right.ChangeCell(player, color, forBlack);
        }

        if (Bottom.CheckCell(color, forBlack))
        {
            Bottom.ChangeCell(player, color, forBlack);
        }

        if (Left.CheckCell(color, forBlack))
        {
            Left.ChangeCell(player, color, forBlack);
        }
    }

    /// <summary>
    /// Конвертер цветов.
    /// </summary>
    /// <param name="colorCell">Цвет нейтральной ячейки.</param>
    /// <returns>Цвет занятой ячейки.</returns>
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

    private void AddScore(ColorCell color)
    {
        if (color == ColorCell.flag)
        {
            var sum = 0;

            foreach (var type in CurrentGame.ActivePlayer.CellCounts)
            {
                sum += type.Value * GetScoreForColor(type.Key);
            }

            MessageBox.Show($"Ты захватил центр! И получили очки: +{sum}!");
            CurrentGame.ActivePlayer.Score += sum;
            return;
        }
        else
        {
            CurrentGame.ActivePlayer.Score += GetScoreForColor(color);
        }

        ++CurrentGame.ActivePlayer.CellCounts[color];
    }

    private int GetScoreForColor(ColorCell color)
        => CurrentGame.ActivePlayer.CellCounts[color] %2 is 0
            ? (int)(6 + color)
            : (int)(1 + color);
}
